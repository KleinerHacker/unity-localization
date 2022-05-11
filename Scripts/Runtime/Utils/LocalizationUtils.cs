using System;
using System.Linq;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Utils
{
    internal static class LocalizationUtils
    {
        public static string GetTextValue(string key, string package, LocalizationTextEditing? overrideTextEditing)
        {
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

            return text;
        }

        public static Sprite GetSpriteValue(string key, string package) => GetValue<Sprite, LocalizedSpriteRow>(key, package)?.Value;

        public static Material GetMaterialValue(string key, string package) => GetValue<Material, LocalizedMaterialRow>(key, package)?.Value;

        private static LocalizedElement<T> GetValue<T, TR>(string key, string package) where TR : LocalizedRow<T> where T : class
        {
            if (string.IsNullOrEmpty(package))
                return default;

            var rows = LocalizationSettings.Singleton.Packages.FirstOrDefault(x => string.Equals(x.Name, package, StringComparison.Ordinal))?.Rows;
            if (rows == null)
                throw new InvalidOperationException("Package with name '" + package + "' not found in localization settings");
            
            var row = rows.FirstOrDefault(x => string.Equals(x.Key, key, StringComparison.Ordinal));
            if (row == null)
                return default;
            if (row is not TR typedRow)
                throw new InvalidOperationException("Requires " + typeof(T).Name + " key!");

            return typedRow.Columns.Find();
        }
    }
}