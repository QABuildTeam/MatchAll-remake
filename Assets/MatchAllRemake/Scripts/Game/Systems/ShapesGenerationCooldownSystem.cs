using Entitas;
using ACFW;
using UnityEngine;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class ShapesGenerationCooldownSystem : IInitializeSystem, IExecuteSystem, ICleanupSystem, ITearDownSystem
    {
        private readonly UniversalEnvironment environment;
        private IGameManager gameManager;
        private readonly GameContext gameContext;
        private GameEntity timer;
        private readonly float objectGenerationPeriod;
        private GameEntity generateShapesCooldown;

        public ShapesGenerationCooldownSystem(Contexts contexts, UniversalEnvironment environment)
        {
            this.environment = environment;
            objectGenerationPeriod = environment.Get<UniversalSettingsManager>().Get<GameSessionSettings>().objectGenerationPeriod;
            gameContext = contexts.game;
        }

        public void Initialize()
        {
            gameManager = environment.Get<IGameManager>();
            timer = gameContext.timerEntity;
            gameContext.isGenerateShapes = false;
            gameContext.SetGenerateShapesCooldown(0);
        }

        public void Execute()
        {
            if (timer.isTimerRunning)
            {
                gameContext.ReplaceGenerateShapesCooldown(gameContext.generateShapesCooldown.cooldown - Time.deltaTime);
                if (gameContext.generateShapesCooldown.cooldown <= 0)
                {
                    gameContext.isGenerateShapes = true;
                    gameContext.ReplaceGenerateShapesCooldown(gameContext.generateShapesCooldown.cooldown + objectGenerationPeriod);
                }
            }
        }

        public void Cleanup()
        {
            gameContext.isGenerateShapes = false;
        }

        public void TearDown()
        {
            gameContext.RemoveGenerateShapesCooldown();
        }
    }
}
