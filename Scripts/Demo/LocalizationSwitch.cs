using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Types;

namespace UnityLocalization.Demo.localization.Scripts.Demo
{
    public sealed class LocalizationSwitch : MonoBehaviour
    {
        #region Inspector Data

        [SerializeField]
        private LocalizedTextRef textRef;

        [SerializeField]
        private LocalizedSpriteRef spriteRef;

        [SerializeField]
        private LocalizedMaterialRef materialRef;

        #endregion
        
        public void HandleSwitch()
        {
            UnityLocalize.CurrentLanguage = UnityLocalize.CurrentLanguage == SystemLanguage.English ? SystemLanguage.German : SystemLanguage.English;
        }
    }
}