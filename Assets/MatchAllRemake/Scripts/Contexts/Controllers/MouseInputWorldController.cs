using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACFW;
using ACFW.Controllers;
using MatchAll.Views;
using System;
using System.Threading.Tasks;

namespace MatchAll.Controllers
{
    public class MouseInputWorldController : ContextController
    {
        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private UniversalSettingsManager SettingsManager => environment.Get<UniversalSettingsManager>();

        private MouseInputWorldView InputView => (MouseInputWorldView)view;
        public MouseInputWorldController(MouseInputWorldView view, UniversalEnvironment environment) : base(view, environment)
        {
        }

        public override async Task Open()
        {
            await base.Open();
            var gameManager = environment.Get<IGameContainer>();
            if (gameManager != null)
            {
                gameManager.PlayerInput = InputView;
            }
        }

        public override async Task Close()
        {
            var gameManager = environment.Get<IGameContainer>();
            if (gameManager != null)
            {
                gameManager.PlayerInput = null;
            }
            await base.Close();
        }
    }
}
