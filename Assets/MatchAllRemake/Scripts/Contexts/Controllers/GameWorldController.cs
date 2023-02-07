using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACFW;
using ACFW.Controllers;
using MatchAll.Environment;
using MatchAll.Views;
using System.Threading.Tasks;

namespace MatchAll.Controllers
{
    public class GameWorldController : ContextController
    {
        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private GameWorldView GameView => (GameWorldView)view;

        public GameWorldController(GameWorldView view, UniversalEnvironment environment) : base(view, environment)
        {
        }

        public override async Task Open()
        {
            await base.Open();
            var gameManager = environment.Get<IGameManager>();
            if (gameManager != null)
            {
                gameManager.CameraController = GameView;
            }
        }

        public override Task Close()
        {
            var gameManager = environment.Get<IGameManager>();
            if (gameManager != null)
            {
                gameManager.CameraController = null;
            }
            return base.Close();
        }

        public void AttachObject(GameObject go, Vector3 position)
        {
            go.transform.SetParent(GameView.WorldTransform);
            go.transform.position = position;
            go.SetActive(true);
        }

        public void DetachObject(GameObject go)
        {
            go.SetActive(false);
            go.transform.SetParent(null);
        }
    }
}
