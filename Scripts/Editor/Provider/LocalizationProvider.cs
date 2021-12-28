using System;
using System.Linq;
using System.Reflection;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEditorInternal;
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
        public static SettingsProvider CreateLocalizationSettingsProvider()
        {
            return new LocalizationProvider();
        }

        #endregion

        private SerializedObject _settings;
        private SerializedProperty _supportedLanguagesProperty;
        private SerializedProperty _fallbackLanguageProperty;
        private SerializedProperty _textRowsProperty;
        private SerializedProperty _spriteRowsProperty;
        private SerializedProperty _materialRowsProperty;
        private SerializedProperty _transliterationProperty;
        private SerializedProperty _textEditingProperty;

        private LocalizationList _textRowList;
        private LocalizationList _spriteRowList;
        private LocalizationList _materialRowList;
        private (SystemLanguage, TransliterationList)[] _transliterationLists = Array.Empty<(SystemLanguage, TransliterationList)>();

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
            _textRowsProperty = _settings.FindProperty("textRows");
            _spriteRowsProperty = _settings.FindProperty("spriteRows");
            _materialRowsProperty = _settings.FindProperty("materialRows");
            _transliterationProperty = _settings.FindProperty("transliterations");
            _textEditingProperty = _settings.FindProperty("textEditing");

            _textRowList = new LocalizationTextList(_settings, _textRowsProperty);
            _spriteRowList = new LocalizationSpriteList(_settings, _spriteRowsProperty);
            _materialRowList = new LocalizationMaterialList(_settings, _materialRowsProperty);
            UpdateTransliterationLists();
        }

        public override void OnInspectorUpdate()
        {
            base.OnInspectorUpdate();
            UpdateTransliterationLists();
        }

        public override void OnGUI(string searchContext)
        {
            _settings.Update();
            UnityLocalize.Settings.UpdateContent();

            var lanDoublet = UnityLocalize.Settings.SupportedLanguages.GroupBy(x => x).Any(x => x.Count() > 1);
            var keyDoublet = UnityLocalize.Settings.Rows.GroupBy(x => x.Key).Any(x => x.Count() > 1);
            
            if (lanDoublet)
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

            EditorGUILayout.Space();
            if (keyDoublet)
            {
                EditorGUILayout.HelpBox("There are key doublets. Please fix this to avoid wrong text choices.", MessageType.Warning);
            }
            if (!lanDoublet)
            {
                EditorGUILayout.LabelField("Text Values", EditorStyles.boldLabel);
                _textRowList.DoLayoutList();
                
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Sprite Values", EditorStyles.boldLabel);
                _spriteRowList.DoLayoutList();
                
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Material Values", EditorStyles.boldLabel);
                _materialRowList.DoLayoutList();
            } 
            else
            {
                EditorGUILayout.HelpBox("Please fix doublet problem above!", MessageType.Error);
            }
            
            EditorGUILayout.Space();
            foreach (var transliterationList in _transliterationLists)
            {
                EditorGUILayout.LabelField("Transliteration for " + transliterationList.Item1, EditorStyles.boldLabel);
                transliterationList.Item2.DoLayoutList();
            }

            UnityLocalize.Settings.UpdateContent();
            _settings.ApplyModifiedProperties();
        }

        private void UpdateTransliterationLists()
        {
            if (_transliterationLists.Length != _supportedLanguagesProperty.arraySize)
            {
                Debug.Log("Update transliteration lists");
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