using System;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityLocalization.Runtime.localization.Scripts.Runtime;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationTransliterationProvider : SettingsProvider
    {
        #region Static Area

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new LocalizationTransliterationProvider();
        }

        #endregion

        private SerializedObject _settings;
        private SerializedProperty _supportedLanguagesProperty;
        private SerializedProperty _transliterationProperty;

        private (SystemLanguage, TransliterationList)[] _transliterationLists = Array.Empty<(SystemLanguage, TransliterationList)>();

        public LocalizationTransliterationProvider() : base("Project/Localization/Transliteration", SettingsScope.Project, new[] { "Localization", "Locale", "Language", "Transliteration", "Replace" })
        {
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            _settings = LocalizationSettings.SerializedSingleton;
            if (_settings == null)
                return;

            _supportedLanguagesProperty = _settings.FindProperty("supportedLanguages");
            _transliterationProperty = _settings.FindProperty("transliterations");

            UpdateTransliterationLists(UnityLocalize.Settings.SupportedLanguages.HasDoublets());
        }

        public override void OnInspectorUpdate()
        {
            base.OnInspectorUpdate();
            UpdateTransliterationLists(UnityLocalize.Settings.SupportedLanguages.HasDoublets());
        }

        public override void OnGUI(string searchContext)
        {
            _settings.Update();

            if (!UnityLocalize.Settings.SupportedLanguages.HasDoublets())
            {
                foreach (var transliterationList in _transliterationLists)
                {
                    EditorGUILayout.LabelField("Transliteration for " + transliterationList.Item1, EditorStyles.boldLabel);
                    transliterationList.Item2.DoLayoutList();
                }
            }
            else
            {
                EditorGUILayout.HelpBox("Please fix doublet problem above!", MessageType.Error);
            }

            _settings.ApplyModifiedProperties();
        }

        private void UpdateTransliterationLists(bool lanDoublet)
        {
            if (!lanDoublet && _transliterationLists.Length != _supportedLanguagesProperty.arraySize)
            {
                Debug.Log("Update transliteration lists");

                _settings.ApplyModifiedProperties();
                _settings.Update();

                LocalizationSettings.Singleton.UpdateSupportedLanguages();

                _settings.ApplyModifiedProperties();
                _settings.Update();

                _transliterationLists = new (SystemLanguage, TransliterationList)[LocalizationSettings.Singleton.SupportedLanguages.Length];
                for (var i = 0; i < _transliterationLists.Length; i++)
                {
                    var property = _transliterationProperty.GetArrayElementAtIndex(i);
                    _transliterationLists[i] = ((SystemLanguage)property.FindPropertyRelative("language").intValue,
                        new TransliterationList(_settings, property.FindPropertyRelative("items")));
                }
            }
        }
    }
}