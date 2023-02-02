using ACFW.Controllers;
using ACFW.Environment;
using MatchAll.Environment;

namespace MatchAll.Controllers
{
    public class MainMenuSwitcher : AbstractContextSwitcher
    {
        protected override void Subscribe()
        {
            EventManager.Get<MainMenuEvents>().OpenMainMenu += OnOpenMainMenu;
        }

        private void OnOpenMainMenu()
        {
            EventManager.Get<ContextEvents>().ActivateContext?.Invoke(nameof(MainMenuGameContext));
        }

        protected override void Unsubscribe()
        {
            EventManager.Get<MainMenuEvents>().OpenMainMenu -= OnOpenMainMenu;
        }
    }
}
