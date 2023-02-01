using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIEditorTools.Controllers;
using MatchAll.Environment;
using MatchAll.Settings;
using UIEditorTools.Environment;
using System;

namespace MatchAll.Controllers
{
    public class MainMenuSwitcher : AbstractContextSwitcher
    {
        protected override void Subscribe()
        {
            EventManager.Get<MainMenuEvents>().OpenMainMenu += OnOpenMainMenu;
        }

        private void OnOpenMainMenu()
        {
            EventManager.Get<ContextEvents>().ActivateContext?.Invoke(nameof(MainMenuGameContext));
        }

        protected override void Unsubscribe()
        {
            EventManager.Get<MainMenuEvents>().OpenMainMenu -= OnOpenMainMenu;
        }
    }
}
