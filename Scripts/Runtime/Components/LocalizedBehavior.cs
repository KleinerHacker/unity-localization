using System;
using UnityEditorEx.Runtime.editor_ex.Scripts.Runtime.Extra;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    public abstract class LocalizedBehavior : MonoBehaviour
    {
        #region Inspector Data

        [SerializeField]
        protected string key;

        [Obsolete("Use " + nameof(packageRef) + " instead")]
        [SerializeField]
        protected string package;

        [AssetChooser(typeof(LocalizationPackage))]
        [SerializeField]
        protected LocalizationPackage packageRef;

        #endregion

        internal abstract void UpdateLanguage();

        #region Builtin Methods

#if UNITY_EDITOR

        protected virtual void OnValidate() => LocalizationUtils.Migrate(this, ref package, ref packageRef);

#endif

        #endregion
    }

    public abstract class LocalizedBehavior<T, TE> : LocalizedBehavior where TE : Component
    {
        private TE _element;

        #region Builtin Methods

        protected virtual void Awake() => _element = GetComponent<TE>();

        protected virtual void Start() => UpdateValue(_element);

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            UpdateValue(GetComponent<TE>());
        }

#endif

        #endregion

        private void UpdateValue(TE element)
        {
            #if LOG_LOCALIZATION
            Debug.Log("[LOCALIZATION] Get value for key " + key + " in package " + packageRef.Name, this);
            #endif
            
            var value = GetValue(key, packageRef);
            if (value != null)
            {
                #if LOG_LOCALIZATION
                Debug.Log("[LOCALIZATION] > Value: " + value);
                #endif
                UpdateElement(value, element);
            }
            else
            {
                Debug.LogWarning("[LOCALIZATION] Unable to find value for key " + key + " in package " + packageRef.Name, this);
            }
        }

        protected abstract T GetValue(string key, LocalizationPackage package);
        protected abstract void UpdateElement(T value, TE element);

        internal sealed override void UpdateLanguage()
        {
#if UNITY_EDITOR
            if (!EditorApplication.isPlaying)
            {
#if LOG_LOCALIZATION
                Debug.Log("[LOCALIZATION] Update language in editor");
#endif
                UpdateValue(GetComponent<TE>());
            }
            else
            {
#endif
#if LOG_LOCALIZATION
                Debug.Log("[LOCALIZATION] Update language in play mode");
#endif
                UpdateValue(_element);
#if UNITY_EDITOR
            }
#endif
        }
    }
}