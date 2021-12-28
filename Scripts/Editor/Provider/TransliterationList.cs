using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class TransliterationList : ReorderableList
    {
        private const float LeftMargin = 15f;
        private const float SpaceMargin = 5f;
        private const float BottomMargin = 2f;
        private const float Height = 20f;

        public TransliterationList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
            drawHeaderCallback += DrawHeaderCallback;
            drawElementCallback += DrawElementCallback;
        }

        private void DrawHeaderCallback(Rect rect)
        {
            var pos = new Rect(rect.x + LeftMargin, rect.y, rect.width / 2f, rect.height);
            EditorGUI.LabelField(pos, new GUIContent("Source Value", "Value to replace with target value"));

            pos = new Rect(rect.x + rect.width / 2f + LeftMargin, rect.y, rect.width / 2f - LeftMargin, rect.height);
            EditorGUI.LabelField(pos, new GUIContent("Target Value", "Value to use for replacement source value"));
        }

        private void DrawElementCallback(Rect rect, int i, bool isactive, bool isfocused)
        {
            var property = serializedProperty.GetArrayElementAtIndex(i);
            var sourceProperty = property.FindPropertyRelative("sourceValue");
            var targetProperty = property.FindPropertyRelative("targetValue");
            
            var pos = new Rect(rect.x, rect.y, rect.width / 2f - SpaceMargin, rect.height - BottomMargin);
            EditorGUI.PropertyField(pos, sourceProperty, GUIContent.none);
            
            pos = new Rect(rect.x + rect.width / 2f, rect.y, rect.width / 2f, rect.height - BottomMargin);
            EditorGUI.PropertyField(pos, targetProperty, GUIContent.none);
        }
    }
}