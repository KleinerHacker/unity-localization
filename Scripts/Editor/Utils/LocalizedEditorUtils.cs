using System;
using System.Linq;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Utils
{
    internal static class LocalizedEditorUtils
    {
        public static void LayoutRowFilter(string name, SerializedProperty keyProperty, SerializedProperty packageProperty, Func<LocalizedRow, bool> filter, Rect? rect = null)
        {
            var package = FindAllPackages().FirstOrDefault(x => x.Name == ((LocalizationPackage) packageProperty.objectReferenceValue)?.Name);
            
            var filteredRows = package?.Rows.Where(filter).ToArray() ?? Array.Empty<LocalizedRow>();
            var index = filteredRows.IndexOf(x => x.Key == keyProperty.stringValue);
            index = rect.HasValue ? 
                EditorGUI.Popup(rect.Value, new GUIContent(name), index, filteredRows.Select(x => new GUIContent(x.Key)).ToArray()) : 
                EditorGUILayout.Popup(new GUIContent(name), index, filteredRows.Select(x => new GUIContent(x.Key)).ToArray());

            if (index >= 0)
            {
                keyProperty.stringValue = filteredRows[index].Key;
            }
        }

        // public static void LayoutPackageFilter(SerializedProperty packageProperty, Rect? rect = null)
        // {
        //     var packages = FindAllPackages();
        //     var packageName = packageProperty.stringValue;
        //
        //     var index = packages.IndexOf(x => string.Equals(x.Name, packageName, StringComparison.Ordinal));
        //     if (rect == null)
        //     {
        //         index = EditorGUILayout.Popup(new GUIContent("Package Name:"), index,
        //             packages.Select(x => x.Name).ToArray());
        //     }
        //     else
        //     {
        //         index = EditorGUI.Popup(rect.Value, new GUIContent("Package Name:"), index,
        //             packages.Select(x => new GUIContent(x.Name)).ToArray());
        //     }
        //
        //     packageProperty.stringValue = index < 0 ? null : packages[index].Name;
        // }
        
        public static LocalizationPackage[] FindAllPackages()
        {
            return AssetDatabase.FindAssets("t:" + nameof(LocalizationPackage))
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<LocalizationPackage>)
                .ToArray();
        }
    }
}