using Entitas;
using Entitas.CodeGeneration.Attributes;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll.Game
{
    [Game, Unique]
    public sealed class ShapeObjectPointComponent : IComponent
    {
        public Vector2Int position;
    }
}
