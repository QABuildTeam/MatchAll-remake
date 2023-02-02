using ACFW;
using ACFW.Controllers;
using MatchAll.Views;

namespace MatchAll.Controllers
{
    public class GameEndMessageUIPair : ViewControllerPair<GameEndMessageUIController, GameEndMessageUIView>
    {
        protected override GameEndMessageUIController GetContextController(GameEndMessageUIView view, UniversalEnvironment environment)
        {
            return new GameEndMessageUIController(view, environment);
        }
    }
}
