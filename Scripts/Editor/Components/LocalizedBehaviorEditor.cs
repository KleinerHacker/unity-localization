using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts.Editor;
using UnityEngine;
using UnityLocalization.Editor.localization.Scripts.Editor.Utils;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Components
{
    public abstract class LocalizedBehaviorEditor : ExtendedEditor
    {
        private SerializedProperty _keyProperty;
        private SerializedProperty _packageProperty;
        private bool _foldout = false;

        protected virtual void OnEnable()
        {
            _keyProperty = serializedObject.FindProperty("key");
            _packageProperty = serializedObject.FindProperty("packageRef");
        }

        public sealed override void OnInspectorGUI()
        {
            serializedObject.Update();

            var packageRef = _packageProperty.objectReferenceValue;
            var keyName = _keyProperty.stringValue;
            _foldout = EditorGUILayout.BeginFoldoutHeaderGroup(_foldout, new GUIContent("Key (" + (packageRef == null ? "<default>" : ((LocalizationPackage)packageRef).Name) + " -> " + keyName + ")"));
            if (_foldout)
            {
                EditorGUILayout.PropertyField(_packageProperty, new GUIContent("Package"));
                
                if (string.IsNullOrWhiteSpace(keyName))
                {
                    EditorGUILayout.HelpBox("No key ist set. Value will not changed at runtime!", MessageType.Warning);
                }

                LocalizedEditorUtils.LayoutRowFilter(_keyProperty.displayName, _keyProperty, _packageProperty, OnFilterRow);

                OnGUI();
            }

            serializedObject.ApplyModifiedProperties();
        }

        protected virtual void OnGUI()
        {
        }

        protected abstract bool OnFilterRow(LocalizedRow row);
    }
}