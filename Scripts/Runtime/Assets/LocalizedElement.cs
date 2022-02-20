using System;
using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Assets
{
    [Serializable]
    public abstract class LocalizedElement
    {
        #region Inspector Data

        [SerializeField]
        private SystemLanguage language = SystemLanguage.English;

        #endregion

        #region Properties

        public SystemLanguage Language
        {
            get => language;
#if UNITY_EDITOR
            set => language = value;
#endif
        }

        #endregion
    }

    [Serializable]
    public sealed class LocalizedElement<T> : LocalizedElement
    {
        #region Inspector Data

        [SerializeField]
        private T value;

        #endregion

        #region Properties

        public T Value
        {
            get => value;
#if UNITY_EDITOR
            set => this.value = value;
#endif
        }

        #endregion
    }
}