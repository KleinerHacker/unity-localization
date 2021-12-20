using System;
using System.Runtime.Serialization;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Assets
{
    [Serializable]
    [KnownType(typeof(LocalizedTextRow))]
    public abstract class LocalizedRow
    {
        #region Inspector Data

        [SerializeField]
        private string key;

        #endregion

        #region Properties

        public string Key
        {
            get => key;
#if UNITY_EDITOR
            set => key = value;
#endif
        }

        #endregion
    }

    [Serializable]
    public abstract class LocalizedRow<T> : LocalizedRow
    {
        #region Inspector Data

        [SerializeField]
        private LocalizedElement<T>[] columns;

        #endregion

        #region Properties

        public LocalizedElement<T>[] Columns
        {
            get => columns;
#if UNITY_EDITOR
            set => columns = value;
#endif
        }

        #endregion
    }

    [Serializable]
    public sealed class LocalizedTextRow : LocalizedRow<string>
    {
        public static implicit operator string(LocalizedTextRow row) => row.Columns.Find()?.Value ?? "";
    }

    [Serializable]
    public sealed class LocalizedElement<T>
    {
        #region Inspector Data

        [SerializeField]
        private SystemLanguage language = SystemLanguage.English;

        [SerializeField]
        private T value;

        #endregion

        #region Properties

        public SystemLanguage Language
        {
            get => language;
#if UNITY_EDITOR
            set => language = value;
#endif
        }

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