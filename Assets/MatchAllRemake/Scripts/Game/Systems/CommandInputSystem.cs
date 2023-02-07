using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class CommandInputSystem : IExecuteSystem
    {
        private UniversalEnvironment environment;
        private readonly GameContext gameContext;
        private readonly IGroup<GameEntity> shapes;
        public CommandInputSystem(Contexts contexts, UniversalEnvironment environment)
        {
            this.environment = environment;
            gameContext = contexts.game;
            shapes = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Shape, GameMatcher.Bounds));
        }

        public void Execute()
        {
            var gameManager = environment.Get<IGameManager>();
            if (gameManager == null)
            {
                return;
            }
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
    }
}
