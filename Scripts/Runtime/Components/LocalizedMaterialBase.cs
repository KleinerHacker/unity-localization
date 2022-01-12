using System;
using System.Linq;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    public abstract class LocalizedMaterialBase<T> : LocalizedBehavior<Material, T> where T : Component
    {
        protected override Material GetValue(string key, string package) => LocalizationUtils.GetMaterialValue(key, package);
    }
}