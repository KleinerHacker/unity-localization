using System;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Types
{
    [Serializable]
    public sealed class LocalizedSpriteRef : LocalizedRef
    {
        public static implicit operator Sprite(LocalizedSpriteRef textRef) => LocalizationUtils.GetSpriteValue(textRef.Key, textRef.PackageRef);
    }
}