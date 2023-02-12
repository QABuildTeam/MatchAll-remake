using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class ShapeSampleSystem : IInitializeSystem, ITearDownSystem
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
            gameContext.shapeSampleEntity.AddShape(ShapeType.None);
            gameContext.shapeSampleEntity.AddColor(0);
        }
        public void TearDown()
        {
            gameContext.shapeSampleEntity.isGenerateSample = false;
            gameContext.isShapeSample = false;
        }
    }
}
