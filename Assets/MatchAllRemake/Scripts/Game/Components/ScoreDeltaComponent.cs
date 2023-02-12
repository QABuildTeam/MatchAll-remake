using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MatchAll.Game
{
    [Game, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class ScoreDeltaComponent : IComponent
    {
        public int scoreDelta;
    }
}
