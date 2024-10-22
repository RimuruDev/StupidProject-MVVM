using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private GameObject sceneRootBinder;

        public void Run()
        {
            Debug.Log($"MainMenu scene loaded");
        }
    }
}