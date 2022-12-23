using UnityAssetLoader.Runtime.asset_loader.Scripts.Runtime;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime
{
    public static class UnityLocalizationEvent
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        public static void Initialize()
        {
            Debug.Log("[LOCALIZATION] Load localization info...");
            AssetResourcesLoader.LoadFromResources<LocalizationSettings>("");
#if LOG_LOCALIZATION
            Debug.Log("[LOCALIZATION] > Localizations supported: " + string.Join(", ", AssetResources.GetAsset<LocalizationSettings>().SupportedLanguages));
#endif
        }
    }
}