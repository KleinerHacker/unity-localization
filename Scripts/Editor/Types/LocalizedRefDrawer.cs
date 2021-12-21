using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts.Editor;
using UnityEngine;
using UnityLocalization.Editor.localization.Scripts.Editor.Utils;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Types
{
    public abstract class LocalizedRefDrawer : ExtendedDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var keyProperty = property.FindPropertyRelative("key");
            LocalizedEditorUtils.OnGUIRowFilter(property.displayName, keyProperty, OnFilterRow, position);
        }
        
        protected abstract bool OnFilterRow(LocalizedRow row);
    }
}