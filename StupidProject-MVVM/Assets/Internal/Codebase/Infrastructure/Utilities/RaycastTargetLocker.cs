using UnityEngine;
using UnityEngine.UI;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Utilities
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public sealed class RaycastTargetLocker : MonoBehaviour
    {
        [SerializeField, HideInInspector] private Image targetImage;

        private void Reset()
        {
            OnValidate();
        }

        private void Awake()
        {
            if (!targetImage.raycastTarget)
                targetImage.raycastTarget = true;
        }

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        private void OnValidate()
        {
            if (targetImage == null)
                targetImage = GetComponent<Image>();

            if (!targetImage.raycastTarget)
                targetImage.raycastTarget = true;
        }
    }
}