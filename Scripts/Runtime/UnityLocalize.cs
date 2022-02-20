using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Components;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime
{
    public static class UnityLocalize
    {
        private static SystemLanguage _currentLanguage = Application.systemLanguage;

        public static SystemLanguage CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                _currentLanguage = value;
                foreach (var behavior in GameObject.FindObjectsOfType<LocalizedBehavior>())
                {
                    behavior.UpdateLanguage();
                }
            }
        }
        
        public static LocalizationSettings Settings => LocalizationSettings.Singleton;
    }
}