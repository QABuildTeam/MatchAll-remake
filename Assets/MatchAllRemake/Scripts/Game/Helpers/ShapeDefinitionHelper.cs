using Entitas;

namespace MatchAll.Game
{
    public static class ShapeDefinitionHelper
    {
        public static void SetShapeColor(this GameEntity entity, int colorIndex)
        {
            entity.ReplaceShapeDefinition(new ShapeDefinition { shapeType = entity.shapeDefinition.ShapeType, colorIndex = colorIndex });
        }
    }
}
