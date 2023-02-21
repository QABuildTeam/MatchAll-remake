using Entitas;
using ACFW;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Game
{
    public class RenderSetObjectsColorSystem : ReactiveSystem<GameEntity>, ITearDownSystem
    {
        private IGameManager gameManager;

        public RenderSetObjectsColorSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
        {
            gameManager = environment.Get<IGameManager>();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                gameManager.SetShapeColor(entity.shapePosition.position, entity.shapeDefinition.definition.colorIndex);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isSetShapeColor;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.SetShapeColor);
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
