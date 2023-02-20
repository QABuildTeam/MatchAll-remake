using ACFW;
using ACFW.Controllers;
using MatchAll.Views;

namespace MatchAll.Controllers
{
    public class GameEndMessageUIPair : ViewControllerPair<GameEndMessageUIController, GameEndMessageUIView>
    {
        protected override GameEndMessageUIController GetContextController(GameEndMessageUIView view, IServiceLocator environment)
        {
            return new GameEndMessageUIController(view, environment);
        }
    }
}
