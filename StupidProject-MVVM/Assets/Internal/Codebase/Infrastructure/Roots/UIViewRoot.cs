using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Roots
{
    [DisallowMultipleComponent]
    public sealed class UIViewRoot : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Transform uiSceneContainer;

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

        public void AttachSceneUI(GameObject sceneUI)
        {
            ClearSceneUI();

            if (sceneUI == null)
            {
                Debug.LogException(new ArgumentNullException(nameof(sceneUI)));
                return;
            }

            sceneUI.transform.SetParent(uiSceneContainer, worldPositionStays: false);
        }

        private void ClearSceneUI()
        {
            var childCount = uiSceneContainer.childCount;

            for (var i = 0; i < childCount; i++)
                Destroy(uiSceneContainer.GetChild(i).gameObject);
        }
    }
}