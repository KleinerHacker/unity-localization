using System;
using System.Linq;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions
{
    internal static class LocalizationExtensions
    {
        public static LocalizedElement<T> Find<T>(this LocalizedElement<T>[] list)
        {
            var element = list.FirstOrDefault(x => x.Language == UnityLocalize.CurrentLanguage);
            if (element == null || element.Value == null)
                return list.FirstOrDefault(x => x.Language == UnityLocalize.Settings.FallbackLanguage);

            return element;
        }
    }
}