using Entitas;
using System.Linq;
using System.Collections.Generic;
using ACFW;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class RepaintObjectsOfColorAndTypeSystem : ReactiveSystem<GameEntity>
    {
        private GameContext gameContext;
        private int[] availableColors;
        public RepaintObjectsOfColorAndTypeSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
        {
            gameContext = contexts.game;
            var settingsManager = environment.Get<ISettingsManager>();
            var shapeSettings = settingsManager.Get<ShapeSettings>();
            availableColors = shapeSettings.AvailableShapeColors;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var r = new System.Random();
            foreach (var repaintDef in entities)
            {
                foreach (var entity in gameContext.GetEntitiesWithShapeDefinition(repaintDef.repaintTypeAndColor.shapeDefinition).ToList())
                {
                    if (entity.hasShapePosition)
                    {
                        var color = availableColors[r.Next(0, availableColors.Length)];
                        entity.SetShapeColor(color);
                        entity.isSetShapeColor = true;
                    }
                }
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.RepaintTypeAndColor);
        }
    }
}
