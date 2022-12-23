using System;
using System.Linq;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Utils
{
    internal static class LocalizationUtils
    {
        public static string GetTextValue(string key, LocalizationPackage package, LocalizationTextEditing? overrideTextEditing)
        {
#if LOG_LOCALIZATION
            Debug.Log("[LOCALIZATION] Try to retrieve text for key " + key + " in package " + (package?.Name ?? "<default>"));
#endif

            var textElement = GetValue<string, LocalizedTextRow>(key, package);
            if (textElement == null)
                return null;

            var text = textElement.Value;

            //Transliteration
            var transliteration = LocalizationSettings.Singleton.Transliterations.FirstOrDefault(x => x.Language == textElement.Language);
            if (transliteration != null)
            {
                text = transliteration.Items.Aggregate(text, (current, item) => current.Replace(item.SourceValue, item.TargetValue));
            }

            //Text Editing
            var textEditing = overrideTextEditing ?? LocalizationSettings.Singleton.TextEditing;
            text = textEditing switch
            {
                LocalizationTextEditing.None => text,
                LocalizationTextEditing.LowerCase => text.ToLower(),
                LocalizationTextEditing.UpperCase => text.ToUpper(),
                _ => throw new NotImplementedException()
            };

#if LOG_LOCALIZATION
            Debug.Log("[LOCALIZATION] Retrieved text is " + text);
#endif
            return text;
        }

        public static Sprite GetSpriteValue(string key, LocalizationPackage package) => GetValue<Sprite, LocalizedSpriteRow>(key, package)?.Value;

        public static Material GetMaterialValue(string key, LocalizationPackage package) => GetValue<Material, LocalizedMaterialRow>(key, package)?.Value;

        private static LocalizedElement<T> GetValue<T, TR>(string key, LocalizationPackage package) where TR : LocalizedRow<T> where T : class
        {
            if (package == null)
                return default;

            var rows = package.Rows;
            var row = rows.FirstOrDefault(x => string.Equals(x.Key, key, StringComparison.Ordinal));
            if (row == null)
                return default;
            if (row is not TR typedRow)
                throw new InvalidOperationException("Requires " + typeof(T).Name + " key!");

            return typedRow.Columns.Find();
        }

#if UNITY_EDITOR
        public static void Migrate(Object context, ref string package, ref LocalizationPackage packageRef)
        {
            //Migration
            if (!string.IsNullOrEmpty(package))
            {
#if LOG_LOCALIZATION
                Debug.Log("[LOCALIZATION] Migrate localization object", context);
#endif

                var p = package;
                packageRef = AssetDatabase.FindAssets("t:" + nameof(LocalizationPackage))
                    .Select(AssetDatabase.GUIDToAssetPath)
                    .Select(AssetDatabase.LoadAssetAtPath<LocalizationPackage>)
                    .FirstOrDefault(x => x.Name == p);
                if (packageRef == null)
                {
                    Debug.LogWarning("[LOCALIZATION] Unable to find package " + package + ", migration failed", context);
                }

                package = null;
                EditorSceneManager.MarkAllScenesDirty();
            }
        }
#endif
    }
}