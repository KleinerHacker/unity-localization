using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Components
{
    public abstract class LocalizedMaterialBaseEditor : LocalizedBehaviorEditor
    {
        protected override bool OnFilterRow(LocalizedRow row) => row is LocalizedMaterialRow;
    }
}