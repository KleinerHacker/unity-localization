using UnityEngine;
using UnityEngine.UI;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    [AddComponentMenu(UnityLocalizationConstants.Menu.Component.UIMenu + "/Localized Text")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Text))]
    public sealed class LocalizedText : LocalizedTextBase<Text>
    {
        protected override void UpdateElement(string value, Text element) => element.text = value;
    }
}