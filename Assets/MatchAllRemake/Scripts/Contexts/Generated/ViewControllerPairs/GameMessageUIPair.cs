using ACFW;
using ACFW.Controllers;
using MatchAll.Views;

namespace MatchAll.Controllers
{
    public class GameMessageUIPair : ViewControllerPair<GameMessageUIController, GameMessageUIView>
    {
        protected override GameMessageUIController GetContextController(GameMessageUIView view, IServiceLocator environment)
        {
            return new GameMessageUIController(view, environment);
        }
    }
}
