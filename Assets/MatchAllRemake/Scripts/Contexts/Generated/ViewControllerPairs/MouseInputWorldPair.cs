using ACFW;
using ACFW.Controllers;
using MatchAll.Views;

namespace MatchAll.Controllers
{
    public class MouseInputWorldPair : ViewControllerPair<MouseInputWorldController, MouseInputWorldView>
    {
        protected override MouseInputWorldController GetContextController(MouseInputWorldView view, UniversalEnvironment environment)
        {
            return new MouseInputWorldController(view, environment);
        }
    }
}
