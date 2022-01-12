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
            _packageProperty = serializedObject.FindProperty("package");
        }

        public sealed override void OnInspectorGUI()
        {
            serializedObject.Update();

            _foldout = EditorGUILayout.BeginFoldoutHeaderGroup(_foldout, new GUIContent("Key (" + _keyProperty.stringValue + ")"));
            if (_foldout)
            {
                if (string.IsNullOrWhiteSpace(_keyProperty.stringValue))
                {
                    EditorGUILayout.HelpBox("No key ist set. Value will not changed at runtime!", MessageType.Warning);
                }

                LocalizedEditorUtils.OnGUIRowFilter(_keyProperty.displayName, _keyProperty, _packageProperty, OnFilterRow);

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