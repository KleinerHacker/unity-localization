using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    
    public abstract class LocalizedTextBase<T> : LocalizedBehavior<string, T> where T : Component
    {
        #region Inspector Data

        [SerializeField]
        private bool overrideTextEditing;

        [SerializeField]
        private LocalizationTextEditing overriddenTextEditing = LocalizationTextEditing.None;

        #endregion
        
        protected override string GetValue(string key) => 
            LocalizationUtils.GetTextValue(key, overrideTextEditing ? overriddenTextEditing : (LocalizationTextEditing?)null);
    }
}