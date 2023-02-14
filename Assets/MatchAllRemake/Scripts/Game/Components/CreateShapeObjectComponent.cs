using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MatchAll.Game
{
    [Game, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class CreateShapeObjectComponent : IComponent
    {
    }
}
