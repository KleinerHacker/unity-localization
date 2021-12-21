using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationSpriteList : LocalizationList
    {
        public LocalizationSpriteList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
        }

        protected override void OnAddCallback(ReorderableList list)
        {
            var localizedSprite = new LocalizedSpriteRow
            {
                Key = "sprite/my.key",
            };
            localizedSprite.Columns = UnityLocalize.Settings.SupportedLanguages.Select(x => localizedSprite.CreateElement(x)).ToArray();
            
            UnityLocalize.Settings.Rows = UnityLocalize.Settings.Rows.Append(localizedSprite).ToArray();
        }

        protected override void OnRemoveCallback(ReorderableList list)
        {
            var tmp = UnityLocalize.Settings.Rows.ToList();
            tmp.RemoveAt(list.index);
            UnityLocalize.Settings.Rows = tmp.ToArray();
        }
    }
}