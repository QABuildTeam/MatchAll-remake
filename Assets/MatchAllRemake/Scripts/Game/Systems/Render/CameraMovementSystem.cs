using Entitas;
using ACFW;

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
            camera.ReplaceCameraPosition(camera.cameraPosition.position + camera.velocity.velocity);
            var gameController = environment.Get<IGameManager>();
            if (gameController == null)
            {
                return;
            }
            gameController.CameraPosition = camera.cameraPosition.position;
        }
    }
}
