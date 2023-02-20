using ACFW.Controllers;
using ACFW.Environment;
using MatchAll.Environment;
using System;

namespace MatchAll.Controllers
{
    public class GameEndMessageSwitcher : AbstractContextSwitcher
    {
        protected override void Subscribe()
        {
            EventManager.Get<GameEndMessageEvents>().OpenWinMessage += OnOpenWinMessage;
            EventManager.Get<GameEndMessageEvents>().OpenFailMessage += OnOpenFailMessage;
            EventManager.Get<GameEndMessageEvents>().CloseEndMessage += OnCloseEndMessage;
        }

        private void OnOpenWinMessage()
        {
            EventManager.Get<ContextEvents>().OpenOverlayContext?.Invoke(nameof(GameEndMessageAppContext));
        }

        private void OnOpenFailMessage()
        {
            EventManager.Get<ContextEvents>().OpenOverlayContext?.Invoke(nameof(GameEndMessageAppContext));
        }

        private void OnCloseEndMessage()
        {
            EventManager.Get<ContextEvents>().CloseOverlayContext?.Invoke(nameof(GameEndMessageAppContext));
        }

        protected override void Unsubscribe()
        {
            EventManager.Get<GameEndMessageEvents>().OpenWinMessage -= OnOpenWinMessage;
            EventManager.Get<GameEndMessageEvents>().OpenFailMessage -= OnOpenFailMessage;
            EventManager.Get<GameEndMessageEvents>().CloseEndMessage -= OnCloseEndMessage;
        }
    }
}
