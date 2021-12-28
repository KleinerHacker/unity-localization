using System;
using System.Linq;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Utils
{
    internal static class LocalizationUtils
    {
        public static string GetTextValue(string key, LocalizationTextEditing? overrideTextEditing)
        {
            var textElement = GetValue<string, LocalizedTextRow>(key);
            if (textElement == null)
                return null;
            
            var text = textElement?.Value;
            
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

        public static Sprite GetSpriteValue(string key) => GetValue<Sprite, LocalizedSpriteRow>(key)?.Value;

        public static Material GetMaterialValue(string key) => GetValue<Material, LocalizedMaterialRow>(key)?.Value;

        private static LocalizedElement<T> GetValue<T, TR>(string key) where TR : LocalizedRow<T> where T : class
        {
            var row = UnityLocalize.Settings.Rows.FirstOrDefault(x => x.Key == key);
            if (row == null)
                return default;
            if (!(row is TR typedRow))
                throw new InvalidOperationException("Requires " + typeof(T).Name + " key!");

            return typedRow.Columns.Find();
        }
    }
}