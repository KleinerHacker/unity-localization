using System;
using System.Linq;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Utils
{
    internal static class LocalizationUtils
    {
        public static string GetTextValue(string key) => GetValue<string, LocalizedTextRow>(key);

        public static Sprite GetSpriteValue(string key) => GetValue<Sprite, LocalizedSpriteRow>(key);

        public static Material GetMaterialValue(string key) => GetValue<Material, LocalizedMaterialRow>(key);

        private static T GetValue<T, TR>(string key) where TR : LocalizedRow<T> where T : class
        {
            var row = UnityLocalize.Settings.Rows.FirstOrDefault(x => x.Key == key);
            if (row is not TR typedRow)
                throw new InvalidOperationException("Requires " + typeof(T).Name + " key!");

            return typedRow.Columns.Find()?.Value;
        }
    }
}