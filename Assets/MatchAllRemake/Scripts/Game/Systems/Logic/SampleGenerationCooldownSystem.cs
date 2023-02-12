using Entitas;
using ACFW;
using UnityEngine;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class SampleGenerationCooldownSystem : IExecuteSystem, ICleanupSystem
    {
        private readonly GameContext gameContext;
        private readonly float sampleGenerationPeriod;

        public SampleGenerationCooldownSystem(Contexts contexts, UniversalEnvironment environment)
        {
            gameContext = contexts.game;
            sampleGenerationPeriod = environment.Get<UniversalSettingsManager>().Get<GameSessionSettings>().sampleGenerationPeriod;
        }

        public void Execute()
        {
            if (gameContext.timerEntity.isTimerRunning)
            {
                var shapeSample = gameContext.shapeSampleEntity;
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
            gameContext.shapeSampleEntity.isGenerateSample = false;
        }
    }
}
