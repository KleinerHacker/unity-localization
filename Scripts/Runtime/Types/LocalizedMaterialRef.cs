using System;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Types
{
    [Serializable]
    public sealed class LocalizedMaterialRef : LocalizedRef
    {
        public static implicit operator Material(LocalizedMaterialRef textRef) => LocalizationUtils.GetMaterialValue(textRef.Key);
    }
}