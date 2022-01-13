using System;
using System.Linq;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts.Editor.Utils.Extensions;
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
        private SerializedProperty _transliterationProperty;
        private SerializedProperty _textEditingProperty;
        private SerializedProperty[] _packagesProperties;

        private LocalizationList[] _textRowList;
        private LocalizationList[] _spriteRowList;
        private LocalizationList[] _materialRowList;
        private (SystemLanguage, TransliterationList)[] _transliterationLists = Array.Empty<(SystemLanguage, TransliterationList)>();

        private int _packageFold = -1;
        private bool _transliterationFold;

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
            _transliterationProperty = _settings.FindProperty("transliterations");
            _textEditingProperty = _settings.FindProperty("textEditing");
            UpdatePackages();

            UpdatePackageLists();
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

            LayoutCommonSettings(out var lanDoublet);

            EditorGUILayout.Space();

            LayoutPackageSettings(lanDoublet);

            EditorGUILayout.Space();

            LayoutTransliterationSettings();

            UnityLocalize.Settings.UpdateContent();
            _settings.ApplyModifiedProperties();
        }

        private void LayoutCommonSettings(out bool lanDoublet)
        {
            lanDoublet = UnityLocalize.Settings.SupportedLanguages.GroupBy(x => x).Any(x => x.Count() > 1);

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
        }

        private void LayoutPackageSettings(bool lanDoublet)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Packages", EditorStyles.boldLabel);
            EditorGUILayout.Space(1f, true);
            if (GUILayout.Button(EditorGUIUtility.IconContent("d_Toolbar Plus"), EditorStyles.iconButton))
            {
                AddPackage();
            }

            if (GUILayout.Button(EditorGUIUtility.IconContent("d_Toolbar Minus"), EditorStyles.iconButton))
            {
                RemovePackage();
            }
            EditorGUILayout.EndHorizontal();

            var anyOpened = false;
            for (var i = 0; i < _packagesProperties.Length; i++)
            {
                var packageProperty = _packagesProperties[i];

                var packageName = packageProperty.FindPropertyRelative("name").stringValue;
                var package = string.IsNullOrEmpty(packageName) ?
                    LocalizationSettings.Singleton.DefaultPackage :
                    LocalizationSettings.Singleton.Packages.FirstOrDefault(x => x.Name == packageName);
                
                var keyDoublet = package?.Rows.GroupBy(x => x.Key).Any(x => x.Count() > 1) ?? false;

                var opened = EditorGUILayout.BeginFoldoutHeaderGroup(_packageFold == i, string.IsNullOrEmpty(packageName) ? "<default>" : packageName);
                if (opened)
                {
                    anyOpened = true;
                    _packageFold = i;
                }
                if (_packageFold == i)
                {
                    if (i != 0)
                    {
                        EditorGUILayout.PropertyField(packageProperty.FindPropertyRelative("name"), new GUIContent("Package Name:"));
                    }
                    
                    if (keyDoublet)
                    {
                        EditorGUILayout.HelpBox("There are key doublets. Please fix this to avoid wrong text choices.", MessageType.Warning);
                    }

                    if (!lanDoublet)
                    {
                        EditorGUILayout.LabelField("Text Values", EditorStyles.boldLabel);
                        _textRowList[i].DoLayoutList();

                        EditorGUILayout.Space();
                        EditorGUILayout.LabelField("Sprite Values", EditorStyles.boldLabel);
                        _spriteRowList[i].DoLayoutList();

                        EditorGUILayout.Space();
                        EditorGUILayout.LabelField("Material Values", EditorStyles.boldLabel);
                        _materialRowList[i].DoLayoutList();
                    }
                    else
                    {
                        EditorGUILayout.HelpBox("Please fix doublet problem above!", MessageType.Error);
                    }
                }
                EditorGUILayout.EndFoldoutHeaderGroup();
            }
            
            if (!anyOpened)
            {
                _packageFold = -1;
            }
        }

        private void LayoutTransliterationSettings()
        {
            _transliterationFold = EditorGUILayout.BeginFoldoutHeaderGroup(_transliterationFold, "Transliterations");
            if (_transliterationFold)
            {
                foreach (var transliterationList in _transliterationLists)
                {
                    EditorGUILayout.LabelField("Transliteration for " + transliterationList.Item1, EditorStyles.boldLabel);
                    transliterationList.Item2.DoLayoutList();
                }
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
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

        private void UpdatePackageLists()
        {
            _settings.ApplyModifiedProperties();
            _settings.Update();
            
            UpdatePackages();
            
            _textRowList = new LocalizationList[_packagesProperties.Length];
            _spriteRowList = new LocalizationList[_packagesProperties.Length];
            _materialRowList = new LocalizationList[_packagesProperties.Length];

            for (var i = 0; i < _packagesProperties.Length; i++)
            {
                _textRowList[i] = new LocalizationMaterialList(_settings, _packagesProperties[i].FindPropertyRelative("textRows"));
                _spriteRowList[i] = new LocalizationMaterialList(_settings, _packagesProperties[i].FindPropertyRelative("spriteRows"));
                _materialRowList[i] = new LocalizationMaterialList(_settings, _packagesProperties[i].FindPropertyRelative("materialRows"));
            }
        }

        private void UpdatePackages()
        {
            var defaultPackageProperty = _settings.FindProperty("defaultPackage");
            _packagesProperties = new[] { defaultPackageProperty }.Concat(_settings.FindProperties("packages")).ToArray();
        }

        private void AddPackage()
        {
            var property = _settings.FindProperty("packages");
            property.InsertArrayElementAtIndex(property.arraySize);
            var subProperty = property.GetArrayElementAtIndex(property.arraySize - 1);
            subProperty.FindPropertyRelative("name").stringValue = Guid.NewGuid().ToString();
            subProperty.FindPropertyRelative("textRows").ClearArray();
            subProperty.FindPropertyRelative("spriteRows").ClearArray();
            subProperty.FindPropertyRelative("materialRows").ClearArray();
            
            UpdatePackageLists();
        }

        private void RemovePackage()
        {
            var genericMenu = new GenericMenu();
            foreach (var packageProperty in _settings.FindProperties("packages"))
            {
                var packageName = packageProperty.FindPropertyRelative("name").stringValue;
                genericMenu.AddItem(new GUIContent(packageName), false, () =>
                {
                    if (EditorUtility.DisplayDialog("Remove Package", "You are sure to delete complete package '" + packageName + "'? All keys will be lost!", "Yes", "No"))
                    {
                        LocalizationSettings.Singleton.Packages = LocalizationSettings.Singleton.Packages.Where(x => x.Name != packageName).ToArray();
                        UpdatePackageLists();
                    }
                });
            }
            genericMenu.ShowAsContext();
        }
    }
}