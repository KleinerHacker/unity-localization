using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityLocalization.Runtime.localization.Scripts.Runtime;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationMaterialList : LocalizationList
    {
        public LocalizationMaterialList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
        }

        protected override void OnAddCallback(ReorderableList list)
        {
            var localizedMaterial = new LocalizedMaterialRow()
            {
                Key = "material/my.key",
            };
            localizedMaterial.Columns = UnityLocalize.Settings.SupportedLanguages.Select(x => localizedMaterial.CreateElement(x)).ToArray();
            
            UnityLocalize.Settings.Rows = UnityLocalize.Settings.Rows.Append(localizedMaterial).ToArray();
        }

        protected override void OnRemoveCallback(ReorderableList list)
        {
            var tmp = UnityLocalize.Settings.Rows.ToList();
            tmp.RemoveAt(list.index);
            UnityLocalize.Settings.Rows = tmp.ToArray();
        }

        protected override void Sort()
        {
            LocalizationSettings.Singleton.MaterialRows = LocalizationSettings.Singleton.MaterialRows.OrderBy(x => x.Key).ToArray();
        }
    }
}