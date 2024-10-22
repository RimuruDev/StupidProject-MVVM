using R3;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    public class UIGameplayRootBinder : MonoBehaviour
    {
        private Subject<Unit> exitSceneSignalSubj;

        public void HandleGoToMoinMenuButtonClicked() =>
            exitSceneSignalSubj?.OnNext(Unit.Default);

        public void Bind(Subject<Unit> exitSceneSignalSubject) => 
            exitSceneSignalSubj = exitSceneSignalSubject;
    }
}