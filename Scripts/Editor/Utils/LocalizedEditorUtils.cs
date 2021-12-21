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
        public static void OnGUIRowFilter(string name, SerializedProperty keyProperty, Func<LocalizedRow, bool> filter, Rect? rect = null)
        {
            var filteredRows = UnityLocalize.Settings.Rows.Where(filter).ToArray();
            var index = filteredRows.IndexOf(x => x.Key == keyProperty.stringValue);
            index = rect.HasValue ? 
                EditorGUI.Popup(rect.Value, new GUIContent(name), index, filteredRows.Select(x => new GUIContent(x.Key)).ToArray()) : 
                EditorGUILayout.Popup(new GUIContent(name), index, filteredRows.Select(x => x.Key).ToArray());

            if (index >= 0)
            {
                keyProperty.stringValue = filteredRows[index].Key;
            }
        }
    }
}