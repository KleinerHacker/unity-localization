using System;
using System.Linq;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Assets
{
    public sealed class LocalizationSettings : ScriptableObject
    {
        #region Static Area

#if UNITY_EDITOR
        private const string Path = "Assets/Resources/localization.asset";
#endif

        public static LocalizationSettings Singleton
        {
            get
            {
#if UNITY_EDITOR
                var settings = AssetDatabase.LoadAssetAtPath<LocalizationSettings>(Path);
                if (settings == null)
                {
                    Debug.Log("Unable to find localization settings, create new");

                    settings = new LocalizationSettings();
                    AssetDatabase.CreateAsset(settings, Path);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }

                return settings;
#else
                return AssetResourcesLoader.Instance.GetAsset<LocalizationSettings>();
#endif
            }
        }

#if UNITY_EDITOR
        public static SerializedObject SerializedSingleton => new SerializedObject(Singleton);
#endif

        #endregion

        #region Inspector Data

        [SerializeField]
        private SystemLanguage[] supportedLanguages = new[] { SystemLanguage.English };

        [SerializeField]
        private SystemLanguage fallbackLanguage = SystemLanguage.English;

        [SerializeField]
        private LocalizedTextRow[] content = Array.Empty<LocalizedTextRow>();

        #endregion

        #region Properties

        public SystemLanguage[] SupportedLanguages => supportedLanguages;

        public SystemLanguage FallbackLanguage
        {
            get => fallbackLanguage;
#if UNITY_EDITOR
            set => fallbackLanguage = value;
#endif
        }

        public LocalizedTextRow[] Content
        {
            get => content;
#if UNITY_EDITOR
            set => content = value;
#endif
        }

        #endregion

#if UNITY_EDITOR
        public void UpdateContent()
        {
            foreach (var row in content)
            {
                if (row.Columns.Length == SupportedLanguages.Length)
                    continue;

                var addedList = SupportedLanguages
                    .Where(x => !row.Columns.Select(x => x.Language).Contains(x))
                    .ToArray();
                var removedList = row.Columns
                    .Select(x => x.Language)
                    .Where(x => !SupportedLanguages.Contains(x))
                    .ToArray();

                //Remove
                row.Columns = row.Columns.Where(x => !removedList.Contains(x.Language)).ToArray();
                //Add
                row.Columns = row.Columns.Concat(addedList.Select(x => new LocalizedElement<string> { Language = x, Value = "text" })).ToArray();
            }
        }
#endif
    }
}