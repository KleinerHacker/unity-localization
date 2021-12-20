using System.Linq;
using PlasticPipe.PlasticProtocol.Client;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils.Extensions;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    [AddComponentMenu(UnityLocalizationConstants.Menu.Component.Root + "/Localized Text")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Text))]
    public sealed class LocalizedText : UIBehaviour
    {
        #region Inspector Data

        [SerializeField]
        private string localizedTextKey;

        #endregion

        private Text _text;

        #region Builtin Methods

        protected override void Start()
        {
            UpdateText(_text);
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            UpdateText(GetComponent<Text>());
        }

#endif

        #endregion

        private void UpdateText(Text text)
        {
            text.text = LocalizationSettings.Singleton.Content.Find<string, LocalizedTextRow>(localizedTextKey)?.Value;
        }
    }
}