#if TEXT_MESH_PRO
using TMPro;
using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    [AddComponentMenu(UnityLocalizationConstants.Menu.Component.MeshMenu + "/Localized Text Mesh UI")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class LocalizedTextMeshUI : LocalizedTextBase<TextMeshProUGUI>
    {
        protected override void UpdateElement(string value, TextMeshProUGUI element) => element.text = value;
    }
}
#endif