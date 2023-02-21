using ACFW;

namespace MatchAll.Game
{
    public class RenderSystems : Feature
    {
        public RenderSystems(Contexts contexts, IServiceLocator environment) : base("Render systems")
        {
            Add(new CameraMovementSystem(contexts, environment));
            Add(new RenderSampleSystem(contexts, environment));
            Add(new RenderCreateObjectsSystem(contexts, environment));
            Add(new RenderSetObjectsColorSystem(contexts, environment));
            Add(new RenderDestroyObjectsSystem(contexts, environment));
            Add(new RenderScoreSystem(contexts, environment));
            Add(new RenderTimerSystem(contexts, environment));
        }
    }
}
