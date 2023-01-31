using UnityEngine;
using UIEditorTools;
using UIEditorTools.Environment;
using UIEditorTools.Settings;
using MatchAll.Controllers;
using MatchAll.Views;

namespace MatchAll.Settings
{
    public class GameMessageUIPair : ViewControllerPair<GameMessageUIController, GameMessageUIView>
    {
        protected override GameMessageUIController GetContextController(GameMessageUIView view, UniversalEnvironment environment)
        {
            return new GameMessageUIController(view, environment);
        }
    }
}
