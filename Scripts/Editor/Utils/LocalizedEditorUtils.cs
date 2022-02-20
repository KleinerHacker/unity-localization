using System;
using System.Linq;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Utils
{
    internal static class LocalizedEditorUtils
    {
        public static void LayoutRowFilter(string name, SerializedProperty keyProperty, SerializedProperty packageProperty, Func<LocalizedRow, bool> filter, Rect? rect = null)
        {
            var package = string.IsNullOrEmpty(packageProperty.stringValue) ?
                UnityLocalize.Settings.DefaultPackage :
                UnityLocalize.Settings.Packages.FirstOrDefault(x => x.Name == packageProperty.stringValue);
            
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

        public static void LayoutPackageFilter(SerializedProperty packageProperty, Rect? rect = null)
        {
            var packages = LocalizationSettings.Singleton.Packages;
            var packageName = packageProperty.stringValue;

            var index = packages.IndexOf(x => string.Equals(x.Name, packageName, StringComparison.Ordinal)) + 1;
            if (rect == null)
            {
                index = EditorGUILayout.Popup(new GUIContent("Package Name:"), index,
                    new[] { "<default>" }.Concat(packages.Select(x => x.Name).ToArray()).ToArray());
            }
            else
            {
                index = EditorGUI.Popup(rect.Value, new GUIContent("Package Name:"), index,
                    new[] { new GUIContent("<default>") }.Concat(packages.Select(x => new GUIContent(x.Name)).ToArray()).ToArray());
            }

            packageProperty.stringValue = index < 1 ? null : packages[index - 1].Name;
        }
    }
}