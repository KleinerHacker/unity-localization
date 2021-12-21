using UnityEditor;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Types;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Types
{
    [CustomPropertyDrawer(typeof(LocalizedTextRef))]
    public sealed class LocalizedTextRefDrawer : LocalizedRefDrawer
    {
        protected override bool OnFilterRow(LocalizedRow row) => row is LocalizedTextRow;
    }
}