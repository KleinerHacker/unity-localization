using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
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
            var keyProperty = property.FindPropertyRelative("key");
            var packageProperty = property.FindPropertyRelative("package");
            var packageName = packageProperty.stringValue;

            position = EditorGUI.IndentedRect(position);
            _foldout = EditorGUI.BeginFoldoutHeaderGroup(new Rect(position.x, position.y, position.width, lineHeight), _foldout, 
                new GUIContent(property.displayName + " (" + GetRefHint(packageName, keyProperty.stringValue) + ")", GetRefTooltip(packageName, keyProperty.stringValue)));
            if (_foldout)
            {
                LocalizedEditorUtils.LayoutPackageFilter(packageProperty, new Rect(position.x, position.y + lineHeight, position.width, lineHeight));
                position = CalculateNext(position);
                LocalizedEditorUtils.LayoutRowFilter(keyProperty.displayName, keyProperty, packageProperty, OnFilterRow, new Rect(position.x, position.y + lineHeight, position.width, lineHeight));
                position = CalculateNext(position);
                DoOnGUI(position, property);
            }
            EditorGUI.EndFoldoutHeaderGroup();
        }

        public sealed override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!_foldout)
                return lineHeight;

            return DoGetPropertyHeight(property) + lineHeight * 2f;
        }

        protected abstract bool OnFilterRow(LocalizedRow row);

        protected virtual void DoOnGUI(Rect position, SerializedProperty property)
        {
        }

        protected virtual float DoGetPropertyHeight(SerializedProperty property) => lineHeight;
        
        protected virtual string GetRefHint(string packageName, string key) => packageName.Limit(15, "...") + " -> " + key.Limit(15, "...");
        protected virtual string GetRefTooltip(string packageName, string key) => packageName + " -> " + key;
    }
}