using System;
using System.Linq;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;

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
        private LocalizedText[] content = Array.Empty<LocalizedText>();

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

        public LocalizedText[] Content
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

    [Serializable]
    [KnownType(typeof(LocalizedText))]
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
    public sealed class LocalizedText : LocalizedRow<string>
    {
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