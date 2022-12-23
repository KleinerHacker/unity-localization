using UnityEditor;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationSpriteList : LocalizationList
    {
        public LocalizationSpriteList(SerializedObject serializedObject, SerializedProperty elements, SerializedProperty supportedLanguagesProperty) : base(serializedObject, elements, supportedLanguagesProperty)
        {
        }

        protected override string KeyPath => "sprite";
    }
}