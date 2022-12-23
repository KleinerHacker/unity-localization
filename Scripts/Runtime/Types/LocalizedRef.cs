using System;
using UnityEditorEx.Runtime.editor_ex.Scripts.Runtime.Extra;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Assets;
using UnityLocalization.Runtime.localization.Scripts.Runtime.Utils;
using Object = UnityEngine.Object;

namespace UnityLocalization.Runtime.localization.Scripts.Runtime.Types
{
    [Serializable]
    public abstract class LocalizedRef
    {
        #region Inspector Data

        [SerializeField]
        private string key;

        [Obsolete("Use " + nameof(packageRef) + " instead")]
        [SerializeField]
        private string package;

        [AssetChooser(typeof(LocalizationPackage))]
        [SerializeField]
        private LocalizationPackage packageRef;

        #endregion

        #region Properties

        public string Key => key;

        public LocalizationPackage PackageRef => packageRef;

        #endregion

#if UNITY_EDITOR
        public void MigrateOnValidate(Object context) => LocalizationUtils.Migrate(context, ref package, ref packageRef);
#endif
    }
}