using UnityEngine;

namespace UIEditorTools.Environment
{
    public class UITransformManager : MonoBehaviour, ITransformManager
    {
        [SerializeField]
        private Transform initialTransform;
        public Transform InitialTransform => initialTransform;

        [SerializeField]
        private Transform workingTransform;
        public Transform WorkingTransform => workingTransform;

    }
}
