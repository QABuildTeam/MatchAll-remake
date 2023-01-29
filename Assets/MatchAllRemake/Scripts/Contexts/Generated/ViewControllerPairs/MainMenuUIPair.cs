using UnityEngine;
using UIEditorTools;
using UIEditorTools.Environment;
using UIEditorTools.Settings;
using MatchAll.Controllers;
using MatchAll.Views;

namespace MatchAll.Settings
{
    public class MainMenuUIPair : ViewControllerPair<MainMenuUIController, MainMenuUIView>
    {
        protected override MainMenuUIController GetContextController(MainMenuUIView view, UniversalEnvironment environment)
        {
            return new MainMenuUIController(view, environment);
        }
    }
}
