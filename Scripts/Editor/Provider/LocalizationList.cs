using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public abstract class LocalizationList : ReorderableList
    {
        private const float LeftMargin = 15f;
        private const float SpaceMargin = 5f;
        private const float BottomMargin = 2f;
        private const float Height = 20f;

        private SerializedProperty _supportedLanguagesProperty;

        protected LocalizationList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
            drawHeaderCallback += OnDrawHeaderCallback;
            drawElementCallback += OnDrawElementCallback;
            onAddCallback += OnAddCallback;
            onRemoveCallback += OnRemoveCallback;
            elementHeight = Height;
            multiSelect = false;

            _supportedLanguagesProperty = serializedObject.FindProperty("supportedLanguages");
        }

        private void OnDrawElementCallback(Rect rect, int index, bool active, bool focused)
        {
            var contentProperty = serializedProperty.GetArrayElementAtIndex(index);
            var keyProperty = contentProperty.FindPropertyRelative("key");
            var columnsProperty = contentProperty.FindPropertyRelative("columns");

            var parts = rect.width / (_supportedLanguagesProperty.arraySize + 1);

            var pos = new Rect(rect.x, rect.y, parts - SpaceMargin, rect.height - BottomMargin);
            EditorGUI.PropertyField(pos, keyProperty, GUIContent.none);

            for (var i = 0; i < _supportedLanguagesProperty.arraySize; i++)
            {
                var valueProperty = columnsProperty.GetArrayElementAtIndex(i).FindPropertyRelative("value");

                pos = new Rect(rect.x + parts * (i + 1), rect.y, parts - SpaceMargin, rect.height - BottomMargin);
                EditorGUI.PropertyField(pos, valueProperty, GUIContent.none);
            }
        }

        private void OnDrawHeaderCallback(Rect rect)
        {
            var parts = (rect.width - LeftMargin) / (_supportedLanguagesProperty.arraySize + 1);

            var pos = new Rect(rect.x + LeftMargin, rect.y, parts, rect.height);
            EditorGUI.LabelField(pos, "Key");

            for (var i = 0; i < _supportedLanguagesProperty.arraySize; i++)
            {
                var supportedLanguageProperty = _supportedLanguagesProperty.GetArrayElementAtIndex(i);

                pos = new Rect(rect.x + LeftMargin + parts * (i + 1), rect.y, parts, rect.height);
                EditorGUI.LabelField(pos, supportedLanguageProperty.enumDisplayNames[supportedLanguageProperty.enumValueIndex]);
            }
        }

        protected abstract void OnAddCallback(ReorderableList list);

        protected abstract void OnRemoveCallback(ReorderableList list);
    }
}