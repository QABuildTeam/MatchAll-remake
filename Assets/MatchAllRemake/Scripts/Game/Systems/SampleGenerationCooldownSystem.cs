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
            shapeSample.AddShapeSampleCooldown(0);
            shapeSample.AddShape(ShapeType.None);
            shapeSample.AddColor(0);
            gameManager.SetShapeSample(ShapeType.None, 0);
            Debug.Log($"timer is {timer}, shapeSample is {shapeSample}");
        }

        public void Execute()
        {
            if (timer.isTimerRunning)
            {
                shapeSample.ReplaceShapeSampleCooldown(shapeSample.shapeSampleCooldown.cooldown - Time.deltaTime);
                if (shapeSample.shapeSampleCooldown.cooldown <= 0)
                {
                    shapeSample.isGenerateShapes = true;
                    shapeSample.ReplaceShapeSampleCooldown(shapeSample.shapeSampleCooldown.cooldown + sampleGenerationPeriod);
                }
            }
        }

        public void Cleanup()
        {
            shapeSample.isGenerateShapes = false;
        }

        public void TearDown()
        {
            gameContext.isShapeSample = false;
        }
    }
}
