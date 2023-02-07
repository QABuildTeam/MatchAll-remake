using ACFW;
using Entitas;

namespace MatchAll.Game
{
    public class InputSystems : Feature
    {
        public InputSystems(Contexts contexts, UniversalEnvironment environment) : base("Input systems")
        {
            Add(new CommandInputSystem(contexts, environment));
        }
    }
}
