using System;
using System.Linq;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    
    public abstract class LocalizedTextBase<T> : LocalizedBehavior<string, T> where T : Component
    {
        protected override string GetValue(string key)
        {
            var row = UnityLocalize.Settings.Rows.FirstOrDefault(x => x.Key == key);
            if (row is not LocalizedTextRow textRow)
                throw new InvalidOperationException("Requires text key!");

            return textRow.Columns.Find()?.Value ?? "";
        }
    }
}