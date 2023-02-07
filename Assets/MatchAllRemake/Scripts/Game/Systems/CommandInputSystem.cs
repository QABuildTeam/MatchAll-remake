using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class CommandInputSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
    {
        private UniversalEnvironment environment;
        private readonly GameContext gameContext;
        private readonly IGroup<GameEntity> shapes;
        private IGameManager gameManager;

        public CommandInputSystem(Contexts contexts, UniversalEnvironment environment)
        {
            this.environment = environment;
            gameContext = contexts.game;
            shapes = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Shape, GameMatcher.Bounds));
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
                foreach (var entity in shapes)
                {
                    if (entity.bounds.xMin <= position.x &&
                        entity.bounds.xMax >= position.x &&
                        entity.bounds.yMin <= position.y &&
                        entity.bounds.yMax >= position.y)
                    {

                    }
                }
            }
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
