using System;
using System.Linq;
using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Assets
{
    [CreateAssetMenu(menuName = UnityLocalizationConstants.Menu.Asset.PackageMenu + "/Package")]
    public sealed class LocalizationPackage : ScriptableObject
    {
        #region Inspector Data

        [SerializeField]
        private string name = Guid.NewGuid().ToString();

        [SerializeField]
        private bool hidePackage;

        [Space]
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

        public bool HidePackage => hidePackage;

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
        public void UpdateContent(SystemLanguage[] supportedLanguages)
        {
            foreach (var row in Rows)
            {
                if (row.RawColumns.Length == supportedLanguages.Length)
                {
                    //Repair if required
                    for (var i = 0; i < row.RawColumns.Length; i++)
                    {
                        row.RawColumns[i].Language = supportedLanguages[i];
                    }
                    
                    continue;
                }

                //Update if required
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
        }
#endif
    }
}