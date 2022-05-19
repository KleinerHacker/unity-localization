using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils;
#if !UNITY_EDITOR
using UnityAssetLoader.Runtime.asset_loader.Scripts.Runtime.Loader;
#endif

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

                    settings = ScriptableObject.CreateInstance<LocalizationSettings>();
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
        private SystemLanguage[] supportedLanguages = { SystemLanguage.English };

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
        private LocalizationTransliteration[] transliterations = Array.Empty<LocalizationTransliteration>();

        [SerializeField]
        private LocalizationTextEditing textEditing = LocalizationTextEditing.None;

        [SerializeField]
        private LocalizationPackage[] packages = Array.Empty<LocalizationPackage>();

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

        public LocalizationPackage[] Packages => packages;

        #endregion

#if UNITY_EDITOR
        public void AddPackage(LocalizationPackage package)
        {
            packages = packages.Append(package).ToArray();
        }
        
        public void UpdateSupportedLanguages()
        {
            var packages = AssetDatabase.FindAssets("t:" + nameof(LocalizationPackage))
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<LocalizationPackage>)
                .ToArray();

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
#endif
    }

    public enum LocalizationTextEditing
    {
        None,
        LowerCase,
        UpperCase
    }
}