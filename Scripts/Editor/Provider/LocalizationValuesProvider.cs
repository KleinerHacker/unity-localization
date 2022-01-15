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
    public sealed class LocalizationValuesProvider : SettingsProvider
    {
        #region Static Area

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new LocalizationValuesProvider();
        }

        #endregion

        private SerializedObject _settings;
        private SerializedProperty[] _packagesProperties;

        private LocalizationList[] _textRowList;
        private LocalizationList[] _spriteRowList;
        private LocalizationList[] _materialRowList;
        
        private int _packageFold = -1;
        
        public LocalizationValuesProvider() : base("Project/Localization/Values", SettingsScope.Project, new[] { "Localization", "Locale", "Language", "Value", "Key", "Package" })
        {
            
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            _settings = LocalizationSettings.SerializedSingleton;
            if (_settings == null)
                return;

            UpdatePackages();
            UpdatePackageLists();
        }

        public override void OnGUI(string searchContext)
        {
            _settings.Update();
            
            EditorGUILayout.Space();
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
            EditorGUILayout.Space(25f);

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

                    if (!UnityLocalize.Settings.SupportedLanguages.HasDoublets())
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

            _settings.ApplyModifiedProperties();
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
                _textRowList[i] = new LocalizationTextList(_settings, _packagesProperties[i].FindPropertyRelative("textRows"));
                _spriteRowList[i] = new LocalizationSpriteList(_settings, _packagesProperties[i].FindPropertyRelative("spriteRows"));
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
                        
                        EditorUtility.SetDirty(LocalizationSettings.Singleton);

                        _settings.ApplyModifiedProperties();
                        _settings.Update();
                    }
                });
            }
            genericMenu.ShowAsContext();
        }
    }
}