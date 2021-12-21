using System;
using System.Linq;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    
    public abstract class LocalizedSpriteBase<T> : LocalizedBehavior<Sprite, T> where T : Component
    {
        protected override Sprite GetValue(string key)
        {
            var row = UnityLocalize.Settings.Rows.FirstOrDefault(x => x.Key == key);
            if (row is not LocalizedSpriteRow spriteRow)
                throw new InvalidOperationException("Requires sprite key!");

            return spriteRow.Columns.Find()?.Value;
        }
    }
}