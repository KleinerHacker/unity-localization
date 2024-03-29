using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    
    public abstract class LocalizedSpriteBase<T> : LocalizedBehavior<Sprite, T> where T : Component
    {
        protected override Sprite GetValue(string key, LocalizationPackage package) => LocalizationUtils.GetSpriteValue(key, package);
    }
}