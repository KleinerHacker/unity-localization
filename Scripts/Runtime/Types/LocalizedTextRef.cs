using System;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Types
{
    [Serializable]
    public sealed class LocalizedTextRef : LocalizedRef
    {
        public static implicit operator string(LocalizedTextRef textRef) => LocalizationUtils.GetTextValue(textRef.Key);
    }
}