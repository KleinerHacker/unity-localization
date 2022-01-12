using UnityEditor;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationSpriteList : LocalizationList
    {
        public LocalizationSpriteList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
        }

        protected override string KeyPath => "sprite";
    }
}