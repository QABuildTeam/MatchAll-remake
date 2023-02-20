using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACFW;
using ACFW.Environment;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class RepaintNeighboursSystem : ReactiveSystem<GameEntity>
    {
        private GameContext gameContext;
        private int neighbourDistance;
        public RepaintNeighboursSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
        {
            gameContext = contexts.game;
            neighbourDistance = environment.Get<ISettingsManager>().Get<GameSessionSettings>().neighbourDistance;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var repaint in entities)
            {
                Vector2Int halfDistance = new Vector2Int(neighbourDistance, neighbourDistance);
                Vector2Int position = repaint.repaintNeightbours.centerPosition - halfDistance;
                var startX = position.x;
                Vector2Int endPosition = repaint.repaintNeightbours.centerPosition + halfDistance;
                for (; position.y <= endPosition.y; ++position.y)
                {
                    for (position.x = startX; position.x <= endPosition.x; ++position.x)
                    {
                        foreach (var entity in gameContext.GetEntitiesWithShapePosition(position))
                        {
                            entity.SetShapeColor(repaint.repaintNeightbours.colorIndex);
                            entity.isSetShapeColor = true;
                        }
                    }
                };
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.RepaintNeightbours);
        }
    }
}
