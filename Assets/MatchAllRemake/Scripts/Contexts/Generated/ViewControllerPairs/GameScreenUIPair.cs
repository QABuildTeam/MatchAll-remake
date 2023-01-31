using UnityEngine;
using UIEditorTools;
using UIEditorTools.Environment;
using UIEditorTools.Settings;
using MatchAll.Controllers;
using MatchAll.Views;

namespace MatchAll.Settings
{
    public class GameScreenUIPair : ViewControllerPair<GameScreenUIController, GameScreenUIView>
    {
        protected override GameScreenUIController GetContextController(GameScreenUIView view, UniversalEnvironment environment)
        {
            return new GameScreenUIController(view, environment);
        }
    }
}
