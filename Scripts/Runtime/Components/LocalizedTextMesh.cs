#if TEXT_MESH_PRO
using TMPro;
using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    [AddComponentMenu(UnityLocalizationConstants.Menu.Component.MeshMenu + "/Localized Text Mesh")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextMeshPro))]
    public sealed class LocalizedTextMesh : LocalizedTextBase<TextMeshPro>
    {
        protected override void UpdateElement(string value, TextMeshPro element) => element.text = value;
    }
}
#endif