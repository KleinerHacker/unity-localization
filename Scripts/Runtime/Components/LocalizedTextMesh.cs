using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    [AddComponentMenu(UnityLocalizationConstants.Menu.Component.MeshMenu + "/Localized Text Mesh")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextMesh))]
    public sealed class LocalizedTextMesh : LocalizedTextBase<TextMesh>
    {
        protected override void UpdateElement(string value, TextMesh element) => element.text = value;
    }
}