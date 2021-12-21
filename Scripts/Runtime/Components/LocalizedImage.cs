using UnityEngine;
using UnityEngine.UI;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    [AddComponentMenu(UnityLocalizationConstants.Menu.Component.UIMenu + "/Localized Image")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class LocalizedImage : LocalizedSpriteBase<Image>
    {
        protected override void UpdateElement(Sprite value, Image element) => element.sprite = value;
    }
}