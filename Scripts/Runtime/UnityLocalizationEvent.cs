using UnityAssetLoader.Runtime.asset_loader.Scripts.Runtime.Loader;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime
{
    public static class UnityLocalizationEvent
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        public static void Initialize()
        {
            Debug.Log("Load localization info...");
            AssetResourcesLoader.Instance.LoadAssets<LocalizationSettings>("");
        }
    }
}