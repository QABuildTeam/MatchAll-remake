using Entitas;
using ACFW;
using UnityEngine;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class SampleGenerationCooldownSystem : IInitializeSystem, IExecuteSystem, ICleanupSystem, ITearDownSystem
    {
        private readonly UniversalEnvironment environment;
        private IGameManager gameManager;
        private readonly GameContext gameContext;
        private GameEntity timer;
        private GameEntity shapeSample;
        private readonly float sampleGenerationPeriod;

        public SampleGenerationCooldownSystem(Contexts contexts, UniversalEnvironment environment)
        {
            this.environment = environment;
            sampleGenerationPeriod = environment.Get<UniversalSettingsManager>().Get<GameSessionSettings>().sampleGenerationPeriod;
            gameContext = contexts.game;
        }

        public void Initialize()
        {
            gameManager = environment.Get<IGameManager>();
            timer = gameContext.timerEntity;
            gameContext.isShapeSample = true;
            shapeSample = gameContext.shapeSampleEntity;
            shapeSample.AddGenerateSampleCooldown(0);
            shapeSample.AddShape(ShapeType.None);
            shapeSample.AddColor(0);
            gameManager.SetShapeSample(ShapeType.None, 0);
        }

        public void Execute()
        {
            if (timer.isTimerRunning)
            {
                shapeSample.ReplaceGenerateSampleCooldown(shapeSample.generateSampleCooldown.cooldown - Time.deltaTime);
                if (shapeSample.generateSampleCooldown.cooldown <= 0)
                {
                    shapeSample.isGenerateSample = true;
                    shapeSample.ReplaceGenerateSampleCooldown(shapeSample.generateSampleCooldown.cooldown + sampleGenerationPeriod);
                }
            }
        }

        public void Cleanup()
        {
            shapeSample.isGenerateSample = false;
        }

        public void TearDown()
        {
            shapeSample.isGenerateSample = false;
            gameContext.isShapeSample = false;
        }
    }
}
