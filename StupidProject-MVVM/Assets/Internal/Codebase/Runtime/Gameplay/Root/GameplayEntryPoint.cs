using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private GameObject sceneRootBinder;

        public void Run()
        {
            Debug.Log($"Gameplay scene loaded");
        }
    }
}