using System;

namespace MatchAll
{
    [Serializable]
    public struct ShapeDefinition
    {
        public ShapeType shapeType;
        public int colorIndex;
        public static bool operator ==(ShapeDefinition a, ShapeDefinition b) => a.Equals(b);
        public static bool operator !=(ShapeDefinition a, ShapeDefinition b) => !a.Equals(b);
        public override bool Equals(object other)
        {
            return shapeType == ((ShapeDefinition)other).shapeType && colorIndex == ((ShapeDefinition)other).colorIndex;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
