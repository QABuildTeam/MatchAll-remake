using ACFW;
using ACFW.Controllers;
using MatchAll.Views;

namespace MatchAll.Controllers
{
    public class MainMenuUIPair : ViewControllerPair<MainMenuUIController, MainMenuUIView>
    {
        protected override MainMenuUIController GetContextController(MainMenuUIView view, IServiceLocator environment)
        {
            return new MainMenuUIController(view, environment);
        }
    }
}
