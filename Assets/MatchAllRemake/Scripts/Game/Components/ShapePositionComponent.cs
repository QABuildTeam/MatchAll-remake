using Entitas;
using Entitas.CodeGeneration.Attributes;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll.Game
{
    [Game]
    public sealed class ShapePositionComponent : IComponent
    {
        [EntityIndex]
        public Vector2Int position;
    }
}
