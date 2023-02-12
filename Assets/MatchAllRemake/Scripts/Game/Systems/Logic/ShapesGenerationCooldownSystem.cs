using Entitas;
using ACFW;
using UnityEngine;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class ShapesGenerationCooldownSystem : IExecuteSystem
    {
        private readonly GameContext gameContext;
        private readonly float objectGenerationPeriod;

        public ShapesGenerationCooldownSystem(Contexts contexts, UniversalEnvironment environment)
        {
            objectGenerationPeriod = environment.Get<UniversalSettingsManager>().Get<GameSessionSettings>().objectGenerationPeriod;
            gameContext = contexts.game;
        }

        public void Execute()
        {
            if (gameContext.timerEntity.isTimerRunning)
            {
                gameContext.ReplaceGenerateShapesCooldown(gameContext.generateShapesCooldown.cooldown - Time.deltaTime);
                if (gameContext.generateShapesCooldown.cooldown <= 0)
                {
                    gameContext.isGenerateShapes = true;
                    gameContext.ReplaceGenerateShapesCooldown(gameContext.generateShapesCooldown.cooldown + objectGenerationPeriod);
                }
            }
        }
    }
}
