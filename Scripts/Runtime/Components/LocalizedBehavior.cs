using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    public abstract class LocalizedBehavior : MonoBehaviour
    {
        #region Inspector Data

        [SerializeField]
        protected string key;

        #endregion

        internal abstract void UpdateLanguage();
    }
    
    public abstract class LocalizedBehavior<T, TE> : LocalizedBehavior where TE : Component
    {
        private TE _element;

        #region Builtin Methods

        protected virtual void Awake() => _element = GetComponent<TE>();

        protected virtual void Start() => UpdateValue(_element);

#if UNITY_EDITOR
        private void OnValidate() => UpdateValue(GetComponent<TE>());

#endif

        #endregion

        private void UpdateValue(TE element)
        {
            var value = GetValue(key);
            UpdateElement(value, element);
        }

        protected abstract T GetValue(string key);
        protected abstract void UpdateElement(T value, TE element);

        internal sealed override void UpdateLanguage() => UpdateValue(_element);
    }
}