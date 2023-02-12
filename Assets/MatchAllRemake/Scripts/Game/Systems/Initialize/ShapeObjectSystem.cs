using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class ShapeObjectSystem : IInitializeSystem, ICleanupSystem, ITearDownSystem
    {
        private readonly GameContext gameContext;
        public ShapeObjectSystem(Contexts contexts, UniversalEnvironment environment)
        {
            gameContext = contexts.game;
        }

        public void Initialize()
        {
            gameContext.SetGenerateShapesCooldown(0);
            gameContext.generateShapesCooldownEntity.isGenerateShapes = false;
        }

        public void Cleanup()
        {
            gameContext.isGenerateShapes = false;
        }

        public void TearDown()
        {
            gameContext.generateShapesCooldownEntity.isGenerateShapes = false;
            gameContext.RemoveGenerateShapesCooldown();
        }
    }
}
