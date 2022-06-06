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
        private SerializedObject[] _packagesObjects;

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
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(25f);

            var anyOpened = false;
            for (var i = 0; i < _packagesObjects.Length; i++)
            {
                var packageObject = _packagesObjects[i];
                packageObject.Update();

                var packageName = packageObject.FindProperty("name").stringValue;
                var packageObj = _packagesObjects.FirstOrDefault(x => x.FindProperty("name").stringValue == packageName);
                var package = (LocalizationPackage)packageObj?.targetObject;
                
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
                        EditorGUILayout.PropertyField(packageObject.FindProperty("name"), new GUIContent("Package Name:"));
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
                
                packageObject.ApplyModifiedProperties();
            }
            
            if (!anyOpened)
            {
                _packageFold = -1;
            }

            if (GUILayout.Button("Search for language packages in project"))
            {
                var packages = AssetDatabase.FindAssets("t:" + nameof(LocalizationPackage))
                    .Select(AssetDatabase.GUIDToAssetPath)
                    .Select(AssetDatabase.LoadAssetAtPath<LocalizationPackage>)
                    .ToArray();

                ((LocalizationSettings)_settings.targetObject).Packages = packages;
                EditorUtility.SetDirty(_settings.targetObject);
                
                UpdatePackages();
                UpdatePackageLists();
            }

            _settings.ApplyModifiedProperties();
        }

        private void UpdatePackageLists()
        {
            _settings.ApplyModifiedProperties();
            _settings.Update();
            
            UpdatePackages();
            
            _textRowList = new LocalizationList[_packagesObjects.Length];
            _spriteRowList = new LocalizationList[_packagesObjects.Length];
            _materialRowList = new LocalizationList[_packagesObjects.Length];

            for (var i = 0; i < _packagesObjects.Length; i++)
            {
                _textRowList[i] = new LocalizationTextList(_settings, _packagesObjects[i].FindProperty("textRows"));
                _spriteRowList[i] = new LocalizationSpriteList(_settings, _packagesObjects[i].FindProperty("spriteRows"));
                _materialRowList[i] = new LocalizationMaterialList(_settings, _packagesObjects[i].FindProperty("materialRows"));
            }
        }

        private void UpdatePackages()
        {
            _packagesObjects = _settings.FindProperties("packages")
                .Select(x => new SerializedObject(x.objectReferenceValue))
                .Where(x => !x.FindProperty("hidePackage").boolValue)
                .OrderBy(x => x.FindProperty("name").stringValue)
                .ToArray();
        }
    }
}