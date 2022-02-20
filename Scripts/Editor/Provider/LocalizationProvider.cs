using System.Linq;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityLocalization.Runtime.localization.Scripts.Runtime;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationProvider : SettingsProvider
    {
        #region Static Area

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new LocalizationProvider();
        }

        #endregion

        private SerializedObject _settings;
        private SerializedProperty _supportedLanguagesProperty;
        private SerializedProperty _fallbackLanguageProperty;
        private SerializedProperty _textEditingProperty;

        public LocalizationProvider() :
            base("Project/Localization", SettingsScope.Project, new[] { "Localization", "Locale", "Language" })
        {
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            _settings = LocalizationSettings.SerializedSingleton;
            if (_settings == null)
                return;

            _supportedLanguagesProperty = _settings.FindProperty("supportedLanguages");
            _fallbackLanguageProperty = _settings.FindProperty("fallbackLanguage");
            _textEditingProperty = _settings.FindProperty("textEditing");
        }

        public override void OnGUI(string searchContext)
        {
            _settings.Update();
            UnityLocalize.Settings.UpdateSupportedLanguages();

            if ( UnityLocalize.Settings.SupportedLanguages.HasDoublets())
            {
                EditorGUILayout.HelpBox("There are doublet language items in supported language list. Please fix this!", MessageType.Warning);
            }

            EditorGUILayout.PropertyField(_supportedLanguagesProperty, new GUIContent("Supported Languages"));
            var index = UnityLocalize.Settings.SupportedLanguages.IndexOf(x => x == UnityLocalize.Settings.FallbackLanguage);
            index = EditorGUILayout.Popup(new GUIContent("Fallback Language"), index, UnityLocalize.Settings.SupportedLanguages.Select(x => x.ToString()).ToArray());
            if (index >= 0)
            {
                UnityLocalize.Settings.FallbackLanguage = UnityLocalize.Settings.SupportedLanguages[index];
            }

            EditorGUILayout.PropertyField(_textEditingProperty, new GUIContent("Mode for text editing", "This can overwritten in components"));

            UnityLocalize.Settings.UpdateSupportedLanguages();
            _settings.ApplyModifiedProperties();
        }
    }
}