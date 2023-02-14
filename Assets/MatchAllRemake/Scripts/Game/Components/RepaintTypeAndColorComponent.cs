using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MatchAll.Game
{
    [Game, Unique, Cleanup(CleanupMode.DestroyEntity)]
    public class RepaintTypeAndColorComponent : IComponent
    {
        public ShapeDefinition shapeDefinition;
    }
}
