using ACFW.Controllers;
using ACFW.Environment;
using MatchAll.Environment;
using System;

namespace MatchAll.Controllers
{
    public class GameMessageSwitcher : AbstractContextSwitcher
    {
        protected override void Subscribe()
        {
            EventManager.Get<GameMessageEvents>().OpenHint += OnOpenHint;
            EventManager.Get<GameMessageEvents>().CloseHint += OnCloseHint;
        }

        private void OnCloseHint()
        {
            EventManager.Get<ContextEvents>().CloseOverlayContext?.Invoke(nameof(GameMessageAppContext));
        }

        private void OnOpenHint()
        {
            EventManager.Get<ContextEvents>().OpenOverlayContext?.Invoke(nameof(GameMessageAppContext));
        }

        protected override void Unsubscribe()
        {
            EventManager.Get<GameMessageEvents>().OpenHint -= OnOpenHint;
            EventManager.Get<GameMessageEvents>().CloseHint -= OnCloseHint;
        }
    }
}
