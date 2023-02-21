using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll.Game
{
    [Game, Unique]
    public sealed class ShapeStatsComponent : IComponent
    {
        public int shapeObjectsCount;
        public Dictionary<ShapeType, int> shapeCount;
        public List<Vector2Int> emptySpaces;
    }
}
