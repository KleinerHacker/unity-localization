using UnityEditor;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationMaterialList : LocalizationList
    {
        public LocalizationMaterialList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
        }

        protected override string KeyPath => "material";
    }
}