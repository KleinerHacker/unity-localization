using UnityEditor;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Types;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Types
{
    [CustomPropertyDrawer(typeof(LocalizedMaterialRef))]
    public sealed class LocalizedMaterialRefDrawer : LocalizedRefDrawer
    {
        protected override bool OnFilterRow(LocalizedRow row) => row is LocalizedMaterialRow;
    }
}