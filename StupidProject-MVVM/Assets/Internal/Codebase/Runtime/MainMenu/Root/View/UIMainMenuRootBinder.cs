using System;
using R3;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.View
{
    public class UIMainMenuRootBinder : MonoBehaviour
    {
        private Subject<Unit> exitSceneSignalSubj;

        public void HandleGoToGameplayButtonClicked() =>
            exitSceneSignalSubj?.OnNext(Unit.Default);

        public void Bind(Subject<Unit> exitSceneSubject) =>
            exitSceneSignalSubj = exitSceneSubject;
    }
}