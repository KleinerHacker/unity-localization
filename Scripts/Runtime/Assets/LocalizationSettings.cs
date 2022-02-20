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
                    if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                    {
                        AssetDatabase.CreateFolder("Assets", "Resources");
                    }

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
        [Obsolete]
        private LocalizedTextRow[] textRows = Array.Empty<LocalizedTextRow>();

        [SerializeField]
        [Obsolete]
        private LocalizedSpriteRow[] spriteRows = Array.Empty<LocalizedSpriteRow>();

        [SerializeField]
        [Obsolete]
        private LocalizedMaterialRow[] materialRows = Array.Empty<LocalizedMaterialRow>();

        [SerializeField]
        private LocalizationPackage defaultPackage = new LocalizationPackage();

        [SerializeField]
        private LocalizationPackage[] packages = Array.Empty<LocalizationPackage>();

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

        public LocalizationTransliteration[] Transliterations => transliterations;

        public LocalizationTextEditing TextEditing => textEditing;

        public LocalizationPackage DefaultPackage => defaultPackage;

        public LocalizationPackage[] Packages
        {
            get => packages;
#if UNITY_EDITOR
            set => packages = value;
#endif
        }

        #endregion

#if UNITY_EDITOR
        public void UpdateSupportedLanguages()
        {
            defaultPackage.UpdateContent(supportedLanguages);
            foreach (var package in packages)
            {
                package.UpdateContent(supportedLanguages);
            }
            
            if (transliterations.Length != supportedLanguages.Length)
            {
                var addedList = supportedLanguages
                    .Where(x => transliterations.All(y => y.Language != x))
                    .ToArray();
                var removedList = transliterations
                    .Select(x => x.Language)
                    .Where(x => !supportedLanguages.Contains(x))
                    .ToArray();

                transliterations = transliterations.Where(x => !removedList
                        .Contains(x.Language))
                    .ToArray();
                transliterations = transliterations
                    .Concat(addedList.Select(x => new LocalizationTransliteration { Language = x }).ToArray())
                    .ToArray();
            }
        }

        private void OnValidate()
        {
            //Migration
            if (textRows is { Length: > 0 })
            {
                defaultPackage.TextRows = defaultPackage.TextRows.Concat(textRows).ToArray();
                textRows = null;
            }

            if (spriteRows is { Length: > 0 })
            {
                defaultPackage.SpriteRows = defaultPackage.SpriteRows.Concat(spriteRows).ToArray();
                spriteRows = null;
            }

            if (materialRows is { Length: > 0 })
            {
                defaultPackage.MaterialRows = defaultPackage.MaterialRows.Concat(materialRows).ToArray();
                materialRows = null;
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