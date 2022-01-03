using UnityEditor;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Components
{
    public abstract class LocalizedTextBaseEditor : LocalizedBehaviorEditor
    {
        private SerializedProperty _overrideTextEditingProperty;
        private SerializedProperty _overriddenTextEditingProperty;
        
        protected override bool OnFilterRow(LocalizedRow row) => row is LocalizedTextRow;

        protected override void OnEnable()
        {
            base.OnEnable();
            _overrideTextEditingProperty = serializedObject.FindProperty("overrideTextEditing");
            _overriddenTextEditingProperty = serializedObject.FindProperty("overriddenTextEditing");
        }

        protected override void OnGUI()
        {
            EditorGUILayout.PropertyField(_overrideTextEditingProperty, new GUIContent("Overwrite Text Editing Mode"));
            if (_overrideTextEditingProperty.boolValue)
            {
                EditorGUILayout.PropertyField(_overriddenTextEditingProperty, new GUIContent("Text Editing (Override)"));
            }
        }
    }
}