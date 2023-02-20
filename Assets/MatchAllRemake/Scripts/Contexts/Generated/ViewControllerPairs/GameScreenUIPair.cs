using ACFW;
using ACFW.Controllers;
using MatchAll.Views;

namespace MatchAll.Controllers
{
    public class GameScreenUIPair : ViewControllerPair<GameScreenUIController, GameScreenUIView>
    {
        protected override GameScreenUIController GetContextController(GameScreenUIView view, IServiceLocator environment)
        {
            return new GameScreenUIController(view, environment);
        }
    }
}
