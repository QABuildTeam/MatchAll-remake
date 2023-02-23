using Entitas;
using ACFW;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class ShapesGenerationCooldownSystem : IExecuteSystem
    {
        private readonly GameContext gameContext;
        private readonly float objectGenerationPeriod;

        public ShapesGenerationCooldownSystem(Contexts contexts, IServiceLocator environment)
        {
            objectGenerationPeriod = environment.Get<ISettingsManager>().Get<GameSessionSettings>().objectGenerationPeriod;
            gameContext = contexts.game;
        }

        public void Execute()
        {
            if (gameContext.timerEntity.isTimerRunning)
            {
                gameContext.ReplaceGenerateShapesCooldown(gameContext.generateShapesCooldown.cooldown - gameContext.timerEntity.timeDelta.timeDelta);
                if (gameContext.generateShapesCooldown.cooldown <= 0)
                {
                    gameContext.isGenerateShapes = true;
                    gameContext.ReplaceGenerateShapesCooldown(gameContext.generateShapesCooldown.cooldown + objectGenerationPeriod);
                }
            }
        }
    }
}
