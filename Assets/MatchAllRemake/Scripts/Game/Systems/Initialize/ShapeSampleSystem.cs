using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class ShapeSampleSystem : IInitializeSystem
    {
        private readonly GameContext gameContext;
        public ShapeSampleSystem(Contexts contexts, UniversalEnvironment environment)
        {
            gameContext = contexts.game;
        }

        public void Initialize()
        {
            gameContext.isShapeSample = true;
            gameContext.shapeSampleEntity.isGenerateSample = false;
            gameContext.shapeSampleEntity.AddGenerateSampleCooldown(0);
            gameContext.shapeSampleEntity.AddShapeDefinition(new ShapeDefinition { shapeType = ShapeType.None, colorIndex = 0 });
        }
    }
}
