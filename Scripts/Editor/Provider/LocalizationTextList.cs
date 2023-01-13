using UnityEditor;
using UnityEngine;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationTextList : LocalizationList
    {
        public LocalizationTextList(SerializedObject serializedObject, SerializedProperty elements, SerializedProperty supportedLanguagesProperty) : base(serializedObject, elements, supportedLanguagesProperty)
        {
            elementHeight = Height * 2f;
        }

        protected override void DrawPropertyField(Rect rect, SerializedProperty valueProperty)
        {
            valueProperty.stringValue = EditorGUI.TextArea(rect, valueProperty.stringValue);
        }

        protected override string KeyPath => "text";
    }
}