using System.Linq;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts.Editor;
using UnityLocalization.Runtime.localization.Scripts.Runtime;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Components
{
    public abstract class LocalizedBehaviorEditor : ExtendedEditor
    {
        private SerializedProperty _keyProperty;

        protected virtual void OnEnable()
        {
            _keyProperty = serializedObject.FindProperty("key");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var filteredRows = UnityLocalize.Settings.Rows.Where(OnFilterRow).ToArray();
            var index = filteredRows.IndexOf(x => x.Key == _keyProperty.stringValue);
            index = EditorGUILayout.Popup(index, filteredRows.Select(x => x.Key).ToArray());
            if (index >= 0)
            {
                _keyProperty.stringValue = filteredRows[index].Key;
            }

            serializedObject.ApplyModifiedProperties();
        }

        protected abstract bool OnFilterRow(LocalizedRow row);
    }
}