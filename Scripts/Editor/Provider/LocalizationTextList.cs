using UnityEditor;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationTextList : LocalizationList
    {
        public LocalizationTextList(SerializedObject serializedObject, SerializedProperty elements, SerializedProperty supportedLanguagesProperty) : base(serializedObject, elements, supportedLanguagesProperty)
        {
        }

        protected override string KeyPath => "text";
    }
}