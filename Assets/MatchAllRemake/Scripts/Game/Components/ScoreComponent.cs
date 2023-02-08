using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MatchAll.Game
{
    [Game, Unique]
    public class ScoreComponent : IComponent
    {
        public int currentScore;
    }
}
