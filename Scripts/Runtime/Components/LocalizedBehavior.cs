using UnityEditor;
using UnityEngine;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Components
{
    public abstract class LocalizedBehavior : MonoBehaviour
    {
        #region Inspector Data

        [SerializeField]
        protected string key;

        [SerializeField]
        protected string package;

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
            var value = GetValue(key, package);
            if (value != null)
            {
                UpdateElement(value, element);
            }
        }

        protected abstract T GetValue(string key, string package);
        protected abstract void UpdateElement(T value, TE element);

        internal sealed override void UpdateLanguage()
        {
#if UNITY_EDITOR
            if (!EditorApplication.isPlaying)
            {
                Debug.Log("Update language in editor");
                UpdateValue(GetComponent<TE>());
            }
            else
            {
#endif
                Debug.Log("Update language in play mode");
                UpdateValue(_element);
#if UNITY_EDITOR
            }
#endif
        }
    }
}