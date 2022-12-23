using System;
using System.Linq;
using UnityEditor;
using UnityEditorEx.Runtime.editor_ex.Scripts.Runtime.Assets;
using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Assets
{
    public sealed class LocalizationSettings : ProviderAsset<LocalizationSettings>
    {
        #region Static Area

        public static LocalizationSettings Singleton => GetSingleton("Localization", "localization.asset");

#if UNITY_EDITOR
        public static SerializedObject SerializedSingleton => GetSerializedSingleton("Localization", "localization.asset");
#endif

        #endregion

        #region Inspector Data

        [SerializeField]
        private SystemLanguage[] supportedLanguages = { SystemLanguage.English };

        [SerializeField]
        private SystemLanguage fallbackLanguage = SystemLanguage.English;

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

        #endregion

#if UNITY_EDITOR
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