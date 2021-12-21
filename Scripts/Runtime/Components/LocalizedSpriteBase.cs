using System;
using System.Linq;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    
    public abstract class LocalizedSpriteBase<T> : LocalizedBehavior<Sprite, T> where T : Component
    {
        protected override Sprite GetValue(string key) => LocalizationUtils.GetSpriteValue(key);
    }
}