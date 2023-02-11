using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MatchAll.Game
{
    [Game, Unique]
    public sealed class GenerateShapesCooldownComponent : IComponent
    {
        public float cooldown;
    }
}
