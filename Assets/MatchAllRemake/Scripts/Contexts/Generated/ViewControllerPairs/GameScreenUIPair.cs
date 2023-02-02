using ACFW;
using ACFW.Controllers;
using MatchAll.Views;

namespace MatchAll.Controllers
{
    public class GameScreenUIPair : ViewControllerPair<GameScreenUIController, GameScreenUIView>
    {
        protected override GameScreenUIController GetContextController(GameScreenUIView view, UniversalEnvironment environment)
        {
            return new GameScreenUIController(view, environment);
        }
    }
}
