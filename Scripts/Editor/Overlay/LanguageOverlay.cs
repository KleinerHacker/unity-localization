using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.Toolbars;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime;
using Object = UnityEngine.Object;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Overlay
{
    [Overlay(typeof(SceneView), "Language")]
    public class LanguageOverlay : ToolbarOverlay
    {
        public LanguageOverlay() : base("Localization/Language")
        {
        }
    }

    [EditorToolbarElement("Localization/Language", typeof(SceneView))]
    public class LanguageButton : EditorToolbarButton
    {
        public LanguageButton()
        {
            tooltip = "Change view of shortcut input";
            icon = (Texture2D)EditorGUIUtility.IconContent("d_Profiler.GlobalIllumination").image;
            clicked += OnClicked;
        }

        private void OnClicked()
        {
            var ctxMenu = new GenericMenu();
            ctxMenu.AddItem(new GUIContent("System Language"), UnityLocalize.CurrentLanguage == Application.systemLanguage, () =>
            {
                UnityLocalize.CurrentLanguage = Application.systemLanguage;
            });
            ctxMenu.AddSeparator(null);
            foreach (var language in Enum.GetValues(typeof(SystemLanguage)).Cast<SystemLanguage>())
            {
                ctxMenu.AddItem(new GUIContent(language.ToString()), UnityLocalize.CurrentLanguage == language, () =>
                {
                    UnityLocalize.CurrentLanguage = language;
                });                
            }
            ctxMenu.ShowAsContext();
        }
    }
}