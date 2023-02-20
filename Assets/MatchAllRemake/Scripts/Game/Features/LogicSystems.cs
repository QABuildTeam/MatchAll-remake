using ACFW;
using Entitas;

namespace MatchAll.Game
{
    public class LogicSystems : Feature
    {
        public LogicSystems(Contexts contexts, IServiceLocator environment) : base("Logic systems")
        {
            Add(new TimeManagementSystem(contexts, environment));
            Add(new SampleGenerationCooldownSystem(contexts, environment));
            Add(new SampleSetupSystem(contexts, environment));
            Add(new ShapesGenerationCooldownSystem(contexts, environment));
            Add(new ShapeSetupSystem(contexts, environment));
            Add(new ShapeObjectHitSystem(contexts, environment));
            Add(new RemoveObjectsOfColorAndTypeSystem(contexts, environment));
            Add(new RepaintNeighboursSystem(contexts, environment));
            Add(new RepaintObjectsOfColorAndTypeSystem(contexts, environment));
            Add(new ScoreManagementSystem(contexts, environment));
            Add(new FinishGameSystem(contexts, environment));
        }
    }
}
