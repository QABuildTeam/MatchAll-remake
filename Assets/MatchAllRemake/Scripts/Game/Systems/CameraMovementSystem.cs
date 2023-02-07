using Entitas;
using ACFW;
using UnityEngine;

namespace MatchAll.Game
{
    public class CameraMovementSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
    {
        private UniversalEnvironment environment;
        private readonly GameContext context;
        private GameEntity camera;
        public CameraMovementSystem(Contexts contexts, UniversalEnvironment environment)
        {
            this.environment = environment;
            context = contexts.game;
        }

        public void Initialize()
        {
            context.isCamera = true;
            camera = context.cameraEntity;
            camera.AddVelocity(0, 0);
            camera.AddPosition(0, 0);
            Debug.Log($"Camera is {camera}");
        }

        public void Execute()
        {
            camera.ReplacePosition(camera.position.x + camera.velocity.x, camera.position.y + camera.velocity.y);
            var gameController = environment.Get<IGameManager>();
            if (gameController == null)
            {
                return;
            }
            gameController.CameraPosition = new Vector2(camera.position.x, camera.position.y);
        }

        public void TearDown()
        {
            context.isCamera = false;
        }
    }
}
