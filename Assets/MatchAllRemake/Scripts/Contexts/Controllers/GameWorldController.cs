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
    public class GameWorldController : ContextController, ICameraController, IShapeObjectsDisplay
    {
        private IEventManager EventManager => environment.Get<IEventManager>();
        private GameWorldView GameView => (GameWorldView)view;

        public GameWorldController(GameWorldView view, IServiceLocator environment) : base(view, environment)
        {
        }

        public override async Task Open()
        {
            var gameManager = environment.Get<IGameContainer>();
            if (gameManager != null)
            {
                gameManager.CameraController = this;
                gameManager.ShapesDisplay = this;
            }
            await base.Open();
            GameView.GameController.Open(environment);
        }

        public override async Task Close()
        {
            var gameManager = environment.Get<IGameContainer>();
            if (gameManager != null)
            {
                gameManager.CameraController = null;
                gameManager.ShapesDisplay = null;
            }
            GameView.GameController.Close();
            await base.Close();
        }

        public Vector2 CameraPosition
        {
            get => (Vector2)GameView?.CameraPosition;
            set
            {
                if (GameView != null)
                {
                    GameView.CameraPosition = value;
                }
            }
        }

        public void CreateShapeObject(ShapeDefinition shapeDefinition, Vector2Int position) => GameView?.CreateShapeObject(shapeDefinition, position);

        public void SetShapeColor(Vector2Int position, int colorIndex) => GameView?.SetShapeColor(position, colorIndex);

        public void DestroyShapeObject(Vector2Int position) => GameView?.DestroyShapeObject(position);
    }
}
