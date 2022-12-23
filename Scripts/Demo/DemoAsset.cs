#if DEMO
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Types;

namespace UnityLocalization.Demo.localization.Scripts.Demo
{
    [CreateAssetMenu(menuName = "Localization/Demo/Demo Asset")]
    public sealed class DemoAsset : ScriptableObject
    {
        [SerializeField]
        private LocalizedTextRef text;

        [SerializeField]
        private int value;

#if UNITY_EDITOR
        private void OnValidate()
        {
            text.MigrateOnValidate(this);
        }
#endif
    }
}
#endif