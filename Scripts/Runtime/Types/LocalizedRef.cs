using System;
using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Types
{
    [Serializable]
    public abstract class LocalizedRef
    {
        #region Inspector Data

        [SerializeField]
        private string key;

        #endregion

        #region Properties

        public string Key => key;

        #endregion
    }
}