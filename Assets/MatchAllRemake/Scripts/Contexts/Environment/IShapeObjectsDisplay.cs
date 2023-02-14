#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll
{
    public interface IShapeObjectsDisplay
    {
        void CreateShapeObject(ShapeDefinition shapeDefinition, Vector2Int position);
        void SetShapeColor(Vector2Int position, int colorIndex);
        void DestroyShapeObject(Vector2Int position);
    }
}
