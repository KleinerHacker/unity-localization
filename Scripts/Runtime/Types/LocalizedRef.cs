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

        [SerializeField]
        private string package;

        #endregion

        #region Properties

        public string Key => key;

        public string Package => package;

        #endregion
    }
}