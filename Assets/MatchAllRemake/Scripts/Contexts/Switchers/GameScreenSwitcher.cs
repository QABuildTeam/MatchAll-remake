using ACFW.Controllers;
using ACFW.Environment;
using MatchAll.Environment;

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
            EventManager.Get<ContextEvents>().ActivateContext?.Invoke(nameof(GameScreenAppContext));
        }

        protected override void Unsubscribe()
        {
            EventManager.Get<GameScreenEvents>().OpenGameScreen -= OnOpenGameScreen;
        }
    }
}
