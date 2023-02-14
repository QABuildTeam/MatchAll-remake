using UnityEngine;

namespace MatchAll.Game
{
    public static class ShapeObjectCellHelper
    {
        public static Vector2Int GetShapeObjectIndex(Vector2 position, float areaXMin, float areaYMin, float objectSlotStep)
        {
            return new Vector2Int { x = (int)((position.x - areaXMin) / objectSlotStep + 0.5f), y = (int)((position.y - areaYMin) / objectSlotStep + 0.5f) };
        }

        public static Vector2 GetShapeObjectPosition(Vector2Int position, float areaXMin, float areaYMin, float objectSlotStep)
        {
            return new Vector2(areaXMin + objectSlotStep * position.x, areaYMin + objectSlotStep * position.y);
        }
    }
}
