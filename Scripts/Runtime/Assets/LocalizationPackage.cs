using System;
using System.Linq;
using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Assets
{
    [Serializable]
    public sealed class LocalizationPackage
    {
        #region Inspector Data

        [SerializeField]
        private string name;

        [SerializeField]
        private LocalizedTextRow[] textRows = Array.Empty<LocalizedTextRow>();

        [SerializeField]
        private LocalizedSpriteRow[] spriteRows = Array.Empty<LocalizedSpriteRow>();

        [SerializeField]
        private LocalizedMaterialRow[] materialRows = Array.Empty<LocalizedMaterialRow>();

        #endregion

        #region Properties

        public string Name
        {
            get => name;
#if UNITY_EDITOR
            set => name = value;
#endif
        }

#if UNITY_EDITOR
        public LocalizedTextRow[] TextRows
        {
            get => textRows;
            set => textRows = value;
        }

        public LocalizedSpriteRow[] SpriteRows
        {
            get => spriteRows;
            set => spriteRows = value;
        }

        public LocalizedMaterialRow[] MaterialRows
        {
            get => materialRows;
            set => materialRows = value;
        }
#endif

        public LocalizedRow[] Rows
        {
            get => textRows.Concat(
                    spriteRows.Concat(
                        materialRows.Cast<LocalizedRow>()
                    )
                )
                .ToArray();
#if UNITY_EDITOR
            set
            {
                textRows = value.Where(x => x is LocalizedTextRow).Cast<LocalizedTextRow>().ToArray();
                spriteRows = value.Where(x => x is LocalizedSpriteRow).Cast<LocalizedSpriteRow>().ToArray();
                materialRows = value.Where(x => x is LocalizedMaterialRow).Cast<LocalizedMaterialRow>().ToArray();
            }
#endif
        }

        #endregion

#if UNITY_EDITOR
        public void UpdateContent(SystemLanguage[] supportedLanguages, LocalizationTransliteration[] transliterations)
        {
            foreach (var row in Rows)
            {
                if (row.RawColumns.Length == supportedLanguages.Length)
                    continue;

                var addedList = supportedLanguages
                    .Where(x => !row.RawColumns.Select(y => y.Language).Contains(x))
                    .ToArray();
                var removedList = row.RawColumns
                    .Select(x => x.Language)
                    .Where(x => !supportedLanguages.Contains(x))
                    .ToArray();

                row.RemoveColumns(removedList);
                row.AddColumns(addedList);
            }

            if (transliterations.Length != supportedLanguages.Length)
            {
                var addedList = supportedLanguages
                    .Where(x => transliterations.All(y => y.Language != x))
                    .ToArray();
                var removedList = transliterations
                    .Select(x => x.Language)
                    .Where(x => !supportedLanguages.Contains(x))
                    .ToArray();

                transliterations = transliterations.Where(x => !removedList
                        .Contains(x.Language))
                    .ToArray();
                transliterations = transliterations
                    .Concat(addedList.Select(x => new LocalizationTransliteration { Language = x }).ToArray())
                    .ToArray();
            }
        }
#endif
    }
}