using Entitas;
using ACFW;
using System.Collections.Generic;

namespace MatchAll.Game
{
    public class RenderSampleSystem : ReactiveSystem<GameEntity>, ITearDownSystem
    {
        private IGameManager gameManager;
        public RenderSampleSystem(Contexts contexts, UniversalEnvironment environment) : base(contexts.game)
        {
            gameManager = environment.Get<IGameManager>();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                gameManager.SetShapeSample(entity.shapeDefinition.definition);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGenerateSample && entity.hasShapeDefinition;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GenerateSample);
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
