using System;
using System.Linq;
using System.Reflection;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationProvider : SettingsProvider
    {
        #region Static Area

        [SettingsProvider]
        public static SettingsProvider CreateLocalizationSettingsProvider()
        {
            return new LocalizationProvider();
        }

        #endregion

        private SerializedObject _settings;
        private SerializedProperty _supportedLanguagesProperty;
        private SerializedProperty _fallbackLanguageProperty;
        private SerializedProperty _contentProperty;

        private LocalizationList _contentList;

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
            _contentProperty = _settings.FindProperty("content");

            _contentList = new LocalizationList(_settings, _contentProperty);
        }

        public override void OnGUI(string searchContext)
        {
            _settings.Update();
            LocalizationSettings.Singleton.UpdateContent();

            var lanDoublet = LocalizationSettings.Singleton.SupportedLanguages.GroupBy(x => x).Any(x => x.Count() > 1);
            var keyDoublet = LocalizationSettings.Singleton.Content.GroupBy(x => x.Key).Any(x => x.Count() > 1);
            
            if (lanDoublet)
            {
                EditorGUILayout.HelpBox("There are doublet language items in supported language list. Please fix this!", MessageType.Warning);
            }

            EditorGUILayout.PropertyField(_supportedLanguagesProperty, new GUIContent("Supported Languages"));
            var index = LocalizationSettings.Singleton.SupportedLanguages.IndexOf(x => x == LocalizationSettings.Singleton.FallbackLanguage);
            index = EditorGUILayout.Popup(new GUIContent("Fallback Language"), index, LocalizationSettings.Singleton.SupportedLanguages.Select(x => x.ToString()).ToArray());
            if (index >= 0)
            {
                LocalizationSettings.Singleton.FallbackLanguage = LocalizationSettings.Singleton.SupportedLanguages[index];
            }

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Value Table", EditorStyles.boldLabel);
            if (keyDoublet)
            {
                EditorGUILayout.HelpBox("There are key doublets. Please fix this to avoid wrong text choices.", MessageType.Warning);
            }
            if (!lanDoublet)
            {
                _contentList.DoLayoutList();
            }
            else
            {
                EditorGUILayout.HelpBox("Please fix doublet problem above!", MessageType.Error);
            }

            LocalizationSettings.Singleton.UpdateContent();
            _settings.ApplyModifiedProperties();
        }
    }
}