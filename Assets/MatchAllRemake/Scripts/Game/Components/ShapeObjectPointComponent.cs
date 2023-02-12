using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MatchAll.Game
{
    [Game, Unique]
    public sealed class ShapeObjectPointComponent : IComponent
    {
        public V2IntPosition position;
    }
}
