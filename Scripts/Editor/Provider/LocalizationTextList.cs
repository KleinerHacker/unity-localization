using UnityEditor;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationTextList : LocalizationList
    {
        public LocalizationTextList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
        }

        protected override string KeyPath => "text";
    }
}