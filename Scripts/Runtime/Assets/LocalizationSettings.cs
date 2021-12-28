using System;
using System.Linq;
#if !UNITY_EDITOR
using UnityAssetLoader.Runtime.asset_loader.Scripts.Runtime.Loader;
#endif
using UnityEditor;
using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Assets
{
    public sealed class LocalizationSettings : ScriptableObject
    {
        #region Static Area

#if UNITY_EDITOR
        private const string Path = "Assets/Resources/localization.asset";
#endif

        public static LocalizationSettings Singleton
        {
            get
            {
#if UNITY_EDITOR
                var settings = AssetDatabase.LoadAssetAtPath<LocalizationSettings>(Path);
                if (settings == null)
                {
                    Debug.Log("Unable to find localization settings, create new");

                    settings = new LocalizationSettings();
                    AssetDatabase.CreateAsset(settings, Path);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }

                return settings;
#else
                return AssetResourcesLoader.Instance.GetAsset<LocalizationSettings>();
#endif
            }
        }

#if UNITY_EDITOR
        public static SerializedObject SerializedSingleton => new SerializedObject(Singleton);
#endif

        #endregion

        #region Inspector Data

        [SerializeField]
        private SystemLanguage[] supportedLanguages = new[] { SystemLanguage.English };

        [SerializeField]
        private SystemLanguage fallbackLanguage = SystemLanguage.English;

        [SerializeField]
        private LocalizedTextRow[] textRows = Array.Empty<LocalizedTextRow>();

        [SerializeField]
        private LocalizedSpriteRow[] spriteRows = Array.Empty<LocalizedSpriteRow>();

        [SerializeField]
        private LocalizedMaterialRow[] materialRows = Array.Empty<LocalizedMaterialRow>();

        [SerializeField]
        private LocalizationTransliteration[] transliterations = Array.Empty<LocalizationTransliteration>();

        [SerializeField]
        private LocalizationTextEditing textEditing = LocalizationTextEditing.None;

        #endregion

        #region Properties

        public SystemLanguage[] SupportedLanguages => supportedLanguages;

        public SystemLanguage FallbackLanguage
        {
            get => fallbackLanguage;
#if UNITY_EDITOR
            set => fallbackLanguage = value;
#endif
        }

        public LocalizedRow[] Rows
        {
            get => textRows.Concat(
                    spriteRows.Concat(
                        materialRows.Cast<LocalizedRow>()
                    )
                )
                .ToArray();
#if UNITY_EDITOR
            set
            {
                textRows = value.Where(x => x is LocalizedTextRow).Cast<LocalizedTextRow>().ToArray();
                spriteRows = value.Where(x => x is LocalizedSpriteRow).Cast<LocalizedSpriteRow>().ToArray();
                materialRows = value.Where(x => x is LocalizedMaterialRow).Cast<LocalizedMaterialRow>().ToArray();
            }
#endif
        }

        public LocalizationTransliteration[] Transliterations => transliterations;

        public LocalizationTextEditing TextEditing => textEditing;

        #endregion

#if UNITY_EDITOR
        public void UpdateContent()
        {
            foreach (var row in Rows)
            {
                if (row.RawColumns.Length == SupportedLanguages.Length)
                    continue;

                var addedList = SupportedLanguages
                    .Where(x => !row.RawColumns.Select(y => y.Language).Contains(x))
                    .ToArray();
                var removedList = row.RawColumns
                    .Select(x => x.Language)
                    .Where(x => !SupportedLanguages.Contains(x))
                    .ToArray();

                row.RemoveColumns(removedList);
                row.AddColumns(addedList);
            }

            if (transliterations.Length != SupportedLanguages.Length)
            {
                var addedList = SupportedLanguages
                    .Where(x => transliterations.All(y => y.Language != x))
                    .ToArray();
                var removedList = transliterations
                    .Select(x => x.Language)
                    .Where(x => !SupportedLanguages.Contains(x))
                    .ToArray();

                transliterations = transliterations.Where(x => !removedList
                    .Contains(x.Language))
                    .ToArray();
                transliterations = transliterations
                    .Concat(addedList.Select(x => new LocalizationTransliteration { Language = x }).ToArray())
                    .ToArray();
            } 
        }
#endif
    }

    public enum LocalizationTextEditing
    {
        None,
        LowerCase,
        UpperCase
    }
}