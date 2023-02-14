using Entitas;
using ACFW;
using System.Collections.Generic;

namespace MatchAll.Game
{
    public class RenderShapeObjectsSystem : ReactiveSystem<GameEntity>, ICleanupSystem, ITearDownSystem
    {
        private IGameManager gameManager;
        private GameContext gameContext;

        public RenderShapeObjectsSystem(Contexts contexts, UniversalEnvironment environment) : base(contexts.game)
        {
            gameManager = environment.Get<IGameManager>();
            gameContext = contexts.game;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.isCreateShapeObject)
                {
                    gameManager.CreateShapeObject(entity.shapeDefinition.definition, entity.shapePosition.position);
                }
                if (entity.isSetShapeColor)
                {
                    gameManager.SetShapeColor(entity.shapePosition.position, entity.shapeDefinition.definition.colorIndex);
                }
                if (entity.isDestroyShapeObject)
                {
                    gameManager.DestroyShapeObject(entity.shapePosition.position);
                    entity.Destroy();
                }
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasShapeDefinition && entity.hasShapePosition;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.ShapeDefinition, GameMatcher.ShapePosition));
        }

        public void Cleanup()
        {
            if (gameContext.hasRemoveTypeAndColor)
            {
                gameContext.RemoveRemoveTypeAndColor();
            }
            if (gameContext.hasRepaintNeightbours)
            {
                gameContext.RemoveRepaintNeightbours();
            }
            if (gameContext.hasRepaintTypeAndColor)
            {
                gameContext.RemoveRepaintTypeAndColor();
            }
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
