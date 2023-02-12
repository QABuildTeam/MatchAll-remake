using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MatchAll.Game
{
    [Game]
    public sealed class ShapePositionComponent : IComponent
    {
        [EntityIndex]
        public V2IntPosition position;
    }
}
