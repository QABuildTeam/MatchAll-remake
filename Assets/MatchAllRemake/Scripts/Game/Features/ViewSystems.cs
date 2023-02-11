using ACFW;

namespace MatchAll.Game
{
    public class ViewSystems : Feature
    {
        public ViewSystems(Contexts contexts, UniversalEnvironment environment) : base("View systems")
        {
            Add(new CameraMovementSystem(contexts, environment));
            Add(new SampleGenerationCooldownSystem(contexts, environment));
            Add(new SampleSetupSystem(contexts, environment));
            Add(new ShapesGenerationCooldownSystem(contexts, environment));
            Add(new ShapeSetupSystem(contexts, environment));
        }
    }
}
