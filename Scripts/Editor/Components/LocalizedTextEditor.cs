using System;
using System.Linq;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts.Editor;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Components;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Components
{
    [CustomEditor(typeof(LocalizedText))]
    public sealed class LocalizedTextEditor : ExtendedEditor
    {
        private SerializedProperty _keyProperty;

        private void OnEnable()
        {
            _keyProperty = serializedObject.FindProperty("localizedTextKey");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var index = LocalizationSettings.Singleton.Content.IndexOf(x => x.Key == _keyProperty.stringValue);
            index = EditorGUILayout.Popup(index, LocalizationSettings.Singleton.Content.Select(x => x.Key).ToArray());
            if (index >= 0)
            {
                _keyProperty.stringValue = LocalizationSettings.Singleton.Content[index].Key;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}