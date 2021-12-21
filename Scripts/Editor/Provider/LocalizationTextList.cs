using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityLocalization.Runtime.localization.Scripts.Runtime;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationTextList : LocalizationList
    {
        public LocalizationTextList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
        }

        protected override void OnAddCallback(ReorderableList list)
        {
            var localizedText = new LocalizedTextRow
            {
                Key = "text/my.key",
            };
            localizedText.Columns = UnityLocalize.Settings.SupportedLanguages.Select(localizedText.CreateElement).ToArray();

            UnityLocalize.Settings.Rows = UnityLocalize.Settings.Rows.Append(localizedText).ToArray();
        }

        protected override void OnRemoveCallback(ReorderableList list)
        {
            var tmp = UnityLocalize.Settings.Rows.ToList();
            tmp.RemoveAt(list.index);
            UnityLocalize.Settings.Rows = tmp.ToArray();
        }
    }
}