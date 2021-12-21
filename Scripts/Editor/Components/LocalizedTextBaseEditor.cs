using UnityEditor;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Components;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Components
{
    public abstract class LocalizedTextBaseEditor : LocalizedBehaviorEditor
    {
        protected override bool OnFilterRow(LocalizedRow row) => row is LocalizedTextRow;
    }
}