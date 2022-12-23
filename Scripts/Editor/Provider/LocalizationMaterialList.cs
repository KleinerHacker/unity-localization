using UnityEditor;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationMaterialList : LocalizationList
    {
        public LocalizationMaterialList(SerializedObject serializedObject, SerializedProperty elements, SerializedProperty supportedLanguagesProperty) : base(serializedObject, elements, supportedLanguagesProperty)
        {
        }

        protected override string KeyPath => "material";
    }
}