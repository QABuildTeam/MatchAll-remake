using ACFW;

namespace MatchAll.Game
{
    public class RenderSystems : Feature
    {
        public RenderSystems(Contexts contexts, UniversalEnvironment environment) : base("Render systems")
        {
            Add(new CameraMovementSystem(contexts, environment));
            Add(new RenderSampleSystem(contexts, environment));
            Add(new RenderShapeObjectsSystem(contexts, environment));
            Add(new RenderScoreSystem(contexts, environment));
            Add(new RenderTimerSystem(contexts, environment));
        }
    }
}
