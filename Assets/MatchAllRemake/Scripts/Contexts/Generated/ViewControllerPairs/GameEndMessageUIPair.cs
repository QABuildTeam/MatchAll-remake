using UnityEngine;
using UIEditorTools;
using UIEditorTools.Environment;
using UIEditorTools.Settings;
using MatchAll.Controllers;
using MatchAll.Views;

namespace MatchAll.Settings
{
    public class GameEndMessageUIPair : ViewControllerPair<GameEndMessageUIController, GameEndMessageUIView>
    {
        protected override GameEndMessageUIController GetContextController(GameEndMessageUIView view, UniversalEnvironment environment)
        {
            return new GameEndMessageUIController(view, environment);
        }
    }
}
