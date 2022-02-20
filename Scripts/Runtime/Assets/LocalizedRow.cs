using System;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Assets
{
    [Serializable]
    public abstract class LocalizedRow
    {
        #region Inspector Data

        [SerializeField]
        private string key;

        #endregion

        #region Properties

        public abstract LocalizedElement[] RawColumns { get; }

        public string Key
        {
            get => key;
#if UNITY_EDITOR
            set => key = value;
#endif
        }

        #endregion

#if UNITY_EDITOR
        public abstract void RemoveColumns(SystemLanguage[] removedLanguages);

        public abstract void AddColumns(SystemLanguage[] addedLanguages);
#endif
    }

    [Serializable]
    public abstract class LocalizedRow<T> : LocalizedRow
    {
        #region Inspector Data

        [SerializeField]
        private LocalizedElement<T>[] columns = Array.Empty<LocalizedElement<T>>();

        #endregion

        #region Properties

        public override LocalizedElement[] RawColumns => columns.Cast<LocalizedElement>().ToArray();

        public LocalizedElement<T>[] Columns
        {
            get => columns;
#if UNITY_EDITOR
            set => columns = value;
#endif
        }

        #endregion

#if UNITY_EDITOR
        public override void RemoveColumns(SystemLanguage[] removedLanguages)
        {
            columns = columns.Where(x => !removedLanguages.Contains(x.Language)).ToArray();
        }

        public override void AddColumns(SystemLanguage[] addedLanguages)
        {
            columns = columns.Concat(addedLanguages.Select(CreateElement)).ToArray();
        }

        public abstract LocalizedElement<T> CreateElement(SystemLanguage language);
#endif
    }

    [Serializable]
    public sealed class LocalizedTextRow : LocalizedRow<string>
    {
#if UNITY_EDITOR
        public override LocalizedElement<string> CreateElement(SystemLanguage language)
        {
            return new LocalizedElement<string>
            {
                Language = language,
                Value = "my.key",
            };
        }
#endif
    }
    
    [Serializable]
    public sealed class LocalizedSpriteRow : LocalizedRow<Sprite>
    {
#if UNITY_EDITOR
        public override LocalizedElement<Sprite> CreateElement(SystemLanguage language)
        {
            return new LocalizedElement<Sprite>
            {
                Language = language,
                Value = null,
            };
        }
#endif
    }
    
    [Serializable]
    public sealed class LocalizedMaterialRow : LocalizedRow<Material>
    {
#if UNITY_EDITOR
        public override LocalizedElement<Material> CreateElement(SystemLanguage language)
        {
            return new LocalizedElement<Material>
            {
                Language = language,
                Value = null,
            };
        }
#endif
    }
}