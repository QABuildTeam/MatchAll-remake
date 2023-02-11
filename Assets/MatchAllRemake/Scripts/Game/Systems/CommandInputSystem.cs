using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class CommandInputSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
    {
        private UniversalEnvironment environment;
        private readonly GameContext gameContext;
        private IGameManager gameManager;

        public CommandInputSystem(Contexts contexts, UniversalEnvironment environment)
        {
            this.environment = environment;
            gameContext = contexts.game;
        }

        public void Initialize()
        {
            gameManager = environment.Get<IGameManager>();
        }

        public void Execute()
        {
            var camera = gameContext.cameraEntity;
            var velocity = gameManager.CameraMovementVelocity;
            camera.ReplaceVelocity(velocity.x, velocity.y);
            if (gameManager.IsFieldPointed == true)
            {
                var position = gameManager.FieldPointer;
            }
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
