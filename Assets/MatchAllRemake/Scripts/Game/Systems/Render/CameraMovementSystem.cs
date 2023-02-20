using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class CameraMovementSystem : IExecuteSystem
    {
        private IServiceLocator environment;
        private readonly GameContext gameContext;
        public CameraMovementSystem(Contexts contexts, IServiceLocator environment)
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
