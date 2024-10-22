using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Roots
{
    [DisallowMultipleComponent]
    public sealed class UIViewRoot : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreen;

        private void Awake()
        {
            HideLoadingScreen();
        }

        public void ShowLoadingScreen()
        {
            loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            loadingScreen.SetActive(false);
        }
    }
}