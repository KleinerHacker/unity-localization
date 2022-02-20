using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    [AddComponentMenu(UnityLocalizationConstants.Menu.Component.SceneMenu + "/Localized Sprite")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class LocalizedSprite : LocalizedSpriteBase<SpriteRenderer>
    {
        protected override void UpdateElement(Sprite value, SpriteRenderer element) => element.sprite = value;
    }
}