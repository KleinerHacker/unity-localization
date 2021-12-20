using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Provider
{
    public sealed class LocalizationList : ReorderableList
    {
        private const float LeftMargin = 15f;
        private const float SpaceMargin = 5f;
        private const float BottomMargin = 2f;
        private const float Height = 20f;

        public LocalizationList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
            drawHeaderCallback += OnDrawHeaderCallback;
            drawElementCallback += OnDrawElementCallback;
            onAddCallback += OnAddCallback;
            onRemoveCallback += OnRemoveCallback;
            elementHeight = Height;
        }

        private void OnDrawElementCallback(Rect rect, int index, bool active, bool focused)
        {
            var parts = rect.width / (LocalizationSettings.Singleton.SupportedLanguages.Length + 1);

            var pos = new Rect(rect.x, rect.y, parts - SpaceMargin, rect.height-BottomMargin);
            LocalizationSettings.Singleton.Content[index].Key = EditorGUI.TextField(pos, LocalizationSettings.Singleton.Content[index].Key);

            for (var i = 0; i < LocalizationSettings.Singleton.SupportedLanguages.Length; i++)
            {
                pos = new Rect(rect.x + parts * (i + 1), rect.y, parts - SpaceMargin, rect.height-BottomMargin);
                EditorGUI.TextField(pos, LocalizationSettings.Singleton.Content[index].Columns[i].Value);
            }
        }

        private void OnDrawHeaderCallback(Rect rect)
        {
            var parts = (rect.width - LeftMargin) / (LocalizationSettings.Singleton.SupportedLanguages.Length + 1);

            var pos = new Rect(rect.x + LeftMargin, rect.y, parts, rect.height);
            EditorGUI.LabelField(pos, "Key");

            for (var i = 0; i < LocalizationSettings.Singleton.SupportedLanguages.Length; i++)
            {
                pos = new Rect(rect.x + LeftMargin + parts * (i + 1), rect.y, parts, rect.height);
                EditorGUI.LabelField(pos, LocalizationSettings.Singleton.SupportedLanguages[i].ToString());
            }
        }

        private void OnAddCallback(ReorderableList list)
        {
            var localizedText = new LocalizedText
            {
                Key = "my.key",
                Columns = LocalizationSettings.Singleton.SupportedLanguages.Select(x => new LocalizedElement<string> { Language = x, Value = "text" }).ToArray()
            };

            LocalizationSettings.Singleton.Content = LocalizationSettings.Singleton.Content.Append(localizedText).ToArray();
        }

        private void OnRemoveCallback(ReorderableList list)
        {
        }
    }
}