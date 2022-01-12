using System;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Types
{
    [Serializable]
    public sealed class LocalizedTextRef : LocalizedRef
    {
        #region Inspector Data

        [SerializeField]
        private bool overrideTextEditing;

        [SerializeField]
        private LocalizationTextEditing overriddenTextEditing = LocalizationTextEditing.None;

        #endregion
        
        public static implicit operator string(LocalizedTextRef textRef) => 
            LocalizationUtils.GetTextValue(textRef.Key, textRef.Package, textRef.overrideTextEditing ? textRef.overriddenTextEditing : (LocalizationTextEditing?)null);
    }
}