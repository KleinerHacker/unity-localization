using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts.Editor;
using UnityEngine;
using UnityLocalization.Editor.localization.Scripts.Editor.Utils;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Types
{
    public abstract class LocalizedRefDrawer : ExtendedDrawer
    {
        private bool _foldout = false;
        
        public sealed override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _foldout = EditorGUI.BeginFoldoutHeaderGroup(position, _foldout, GUIContent.none);
            
            var keyProperty = property.FindPropertyRelative("key");
            LocalizedEditorUtils.OnGUIRowFilter(property.displayName, keyProperty, OnFilterRow, new Rect(position.x, position.y, position.width, lineHeight));

            if (_foldout)
            {
                DoOnGUI(position, property);
            }
            
            EditorGUI.EndFoldoutHeaderGroup();
        }

        public sealed override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!_foldout)
                return lineHeight;

            return DoGetPropertyHeight(property);
        }

        protected abstract bool OnFilterRow(LocalizedRow row);

        protected virtual void DoOnGUI(Rect position, SerializedProperty property)
        {
        }

        protected virtual float DoGetPropertyHeight(SerializedProperty property) => lineHeight;
    }
}