using System.Linq;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts.Editor;
using UnityLocalization.Editor.localization.Scripts.Editor.Utils;
using UnityLocalization.Runtime.localization.Scripts.Runtime;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Components
{
    public abstract class LocalizedBehaviorEditor : ExtendedEditor
    {
        private SerializedProperty _keyProperty;

        protected virtual void OnEnable()
        {
            _keyProperty = serializedObject.FindProperty("key");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            if (string.IsNullOrWhiteSpace(_keyProperty.stringValue))
            {
                EditorGUILayout.HelpBox("No key ist set. Value will not changed at runtime!", MessageType.Warning);
            }
            LocalizedEditorUtils.OnGUIRowFilter(_keyProperty.displayName, _keyProperty, OnFilterRow);
            
            serializedObject.ApplyModifiedProperties();
        }

        protected abstract bool OnFilterRow(LocalizedRow row);
    }
}