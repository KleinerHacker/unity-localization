using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Types;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Types
{
    [CustomPropertyDrawer(typeof(LocalizedTextRef))]
    public sealed class LocalizedTextRefDrawer : LocalizedRefDrawer
    {
        protected override bool OnFilterRow(LocalizedRow row) => row is LocalizedTextRow;

        protected override void DoOnGUI(Rect position, SerializedProperty property)
        {
            var overrideTextEditingProperty = property.FindPropertyRelative("overrideTextEditing");
            var overriddenTextEditingProperty = property.FindPropertyRelative("overriddenTextEditing");

            var pos = new Rect(position.x, position.y + lineHeight, position.width, lineHeight);
            EditorGUI.PropertyField(pos, overrideTextEditingProperty, new GUIContent("Override Text Editing"));
            if (overrideTextEditingProperty.boolValue)
            {
                pos = CalculateNext(pos);
                EditorGUI.PropertyField(pos, overriddenTextEditingProperty, new GUIContent("Text Editing (Override)"));
            }
        }

        protected override float DoGetPropertyHeight(SerializedProperty property)
        {
            var overrideTextEditingProperty = property.FindPropertyRelative("overrideTextEditing");
            if (overrideTextEditingProperty.boolValue)
            {
                return lineHeight * 3f + 5f;
            }
            else
            {
                return lineHeight * 2f + 5f;
            }
        }

        protected override string GetRefHint(LocalizationPackage package, string key)
        {
            if (package == null)
                return "Package not found";
            
            var settings = LocalizationSettings.Singleton;

            var row = package.TextRows.FirstOrDefault(x => string.Equals(x.Key, key));
            if (row == null || row.RawColumns.Length <= 0)
                return "<unknown>";

            return row.Columns.FirstOrDefault(x => x.Language == settings.FallbackLanguage)?.Value ?? row.Columns[0].Value;
        }
    }
}