using Entitas;
using ACFW;
using UnityEngine;

namespace MatchAll.Game
{
    public class CameraMovementSystem : IExecuteSystem
    {
        private UniversalEnvironment environment;
        private readonly GameContext gameContext;
        public CameraMovementSystem(Contexts contexts, UniversalEnvironment environment)
        {
            this.environment = environment;
            gameContext = contexts.game;
        }

        public void Execute()
        {
            var camera = gameContext.cameraEntity;
            camera.ReplaceCameraPosition(camera.cameraPosition.x + camera.velocity.x, camera.cameraPosition.y + camera.velocity.y);
            var gameController = environment.Get<IGameManager>();
            if (gameController == null)
            {
                return;
            }
            gameController.CameraPosition = new Vector2(camera.cameraPosition.x, camera.cameraPosition.y);
            if (camera.velocity.x != 0 || camera.velocity.y != 0)
            {
                Debug.Log($"Camera position=({camera.cameraPosition.x},{camera.cameraPosition.y})");
            }
        }
    }
}
