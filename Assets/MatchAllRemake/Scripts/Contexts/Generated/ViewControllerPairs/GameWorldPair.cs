using ACFW;
using ACFW.Controllers;
using MatchAll.Views;

namespace MatchAll.Controllers
{
    public class GameWorldPair : ViewControllerPair<GameWorldController, GameWorldView>
    {
        protected override GameWorldController GetContextController(GameWorldView view, IServiceLocator environment)
        {
            return new GameWorldController(view, environment);
        }
    }
}
