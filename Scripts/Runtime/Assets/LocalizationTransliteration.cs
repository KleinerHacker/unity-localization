using System;
using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Assets
{
    [Serializable]
    public sealed class LocalizationTransliteration
    {
        #region Inspector Data

        [SerializeField]
        private SystemLanguage language;

        [SerializeField]
        private LocalizationTransliterationItem[] items;

        #endregion

        #region Properties

        public SystemLanguage Language
        {
            get => language;
#if UNITY_EDITOR
            set => language = value;
#endif
        }

        public LocalizationTransliterationItem[] Items => items;

        #endregion
    }

    [Serializable]
    public sealed class LocalizationTransliterationItem
    {
        #region Inspector Data

        [SerializeField]
        private string sourceValue;

        [SerializeField]
        private string targetValue;

        #endregion

        #region Properties

        public string SourceValue => sourceValue;

        public string TargetValue => targetValue;

        #endregion
    }
}