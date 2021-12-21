using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    [AddComponentMenu(UnityLocalizationConstants.Menu.Component.SceneMenu + "/Localized Renderer")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class LocalizedRenderer : LocalizedMaterialBase<Renderer>
    {
        #region Inspector Data

        [SerializeField]
        private int materialIndex;

        #endregion
        
        protected override void UpdateElement(Material value, Renderer element) => element.materials[materialIndex] = value;
    }
}