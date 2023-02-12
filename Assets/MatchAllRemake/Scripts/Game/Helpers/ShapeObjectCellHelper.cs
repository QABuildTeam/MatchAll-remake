using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Game
{
    public static class ShapeObjectCellHelper
    {
        public static V2IntPosition GetShapeObjectIndex(float x, float y, float areaXMin, float areaYMin, float objectSlotStep)
        {
            return new V2IntPosition { x = (int)((x - areaXMin) / objectSlotStep + 0.5f), y = (int)((y - areaYMin) / objectSlotStep + 0.5f) };
        }

        public static Vector2 GetShapeObjectPosition(V2IntPosition position, float areaXMin, float areaYMin, float objectSlotStep)
        {
            return new Vector2(areaXMin + objectSlotStep * position.x, areaYMin + objectSlotStep * position.y);
        }
    }
}
