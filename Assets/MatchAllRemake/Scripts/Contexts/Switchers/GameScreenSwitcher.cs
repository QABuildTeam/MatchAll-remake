using UIEditorTools.Controllers;
using MatchAll.Environment;
using MatchAll.Settings;
using UIEditorTools.Environment;
using System;

namespace MatchAll.Controllers
{
    public class GameScreenSwitcher : AbstractContextSwitcher
    {
        protected override void Subscribe()
        {
            EventManager.Get<GameScreenEvents>().OpenGameScreen += OnOpenGameScreen;
        }

        private void OnOpenGameScreen()
        {
            EventManager.Get<ContextEvents>().ActivateContext?.Invoke(nameof(GameScreenGameContext));
        }

        protected override void Unsubscribe()
        {
            EventManager.Get<GameScreenEvents>().OpenGameScreen -= OnOpenGameScreen;
        }
    }
}
