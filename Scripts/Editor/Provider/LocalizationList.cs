using System;
using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts.Editor.Utils.Extensions;
using UnityEditorInternal;
using UnityEngine;

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
            _supportedLanguagesProperty = serializedObject.FindProperty("supportedLanguages");

            drawHeaderCallback += OnDrawHeaderCallback;
            drawElementCallback += OnDrawElementCallback;
            onAddCallback += OnAddCallback;
            onRemoveCallback += OnRemoveCallback;
            elementHeight = Height;
            multiSelect = false;
        }

        private void OnDrawHeaderCallback(Rect rect)
        {
            if (GUI.Button(new Rect(rect.x - 2f, rect.y + 1f, 20f, 20f), EditorGUIUtility.IconContent("AlphabeticalSorting"), EditorStyles.iconButton))
            {
                Sort();
            }

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

        private void OnAddCallback(ReorderableList list)
        {
            serializedProperty.InsertArrayElementAtIndex(serializedProperty.arraySize);
            var property = serializedProperty.GetArrayElementAtIndex(serializedProperty.arraySize - 1);
            property.FindPropertyRelative("key").stringValue = KeyPath + "/" + Guid.NewGuid();
        }

        private void OnRemoveCallback(ReorderableList list)
        {
            serializedProperty.DeleteArrayElementAtIndex(list.index);
        }

        protected abstract string KeyPath { get; }

        private void Sort()
        {
            serializedProperty.OrderBy(p => p.FindPropertyRelative("key").stringValue);
        }
    }
}