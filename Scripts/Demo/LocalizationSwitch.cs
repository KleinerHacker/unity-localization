using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime;

namespace UnityLocalization.Demo.localization.Scripts.Demo
{
    public sealed class LocalizationSwitch : MonoBehaviour
    {
        public void HandleSwitch()
        {
            UnityLocalize.CurrentLanguage = UnityLocalize.CurrentLanguage == SystemLanguage.English ? SystemLanguage.German : SystemLanguage.English;
        }
    }
}