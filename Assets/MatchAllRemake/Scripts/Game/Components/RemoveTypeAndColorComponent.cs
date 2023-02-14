using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MatchAll.Game
{
    [Game, Unique, Cleanup(CleanupMode.DestroyEntity)]
    public class RemoveTypeAndColorComponent : IComponent
    {
        public ShapeDefinition shapeDefinition;
    }
}
