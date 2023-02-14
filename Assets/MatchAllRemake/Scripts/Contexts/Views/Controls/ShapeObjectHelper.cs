using MatchAll.Settings;

namespace MatchAll.Views
{
    public static class ShapeObjectHelper
    {
        public static ResolvedShapeObject Resolve(ShapeDefinition shapeObject, ShapeSettings settings)
        {
            var reference = settings.GetShapeSpriteReference(shapeObject.shapeType);
            var color = settings.GetShapeColor(shapeObject.colorIndex);
            return new ResolvedShapeObject { spriteReference = reference, spriteColor = color };
        }
    }
}
