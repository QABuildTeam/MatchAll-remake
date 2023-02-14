using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MatchAll.Game
{
    [Game]
    public sealed class ShapeDefinitionComponent : IComponent
    {
        [EntityIndex]
        public ShapeDefinition definition;
        [EntityIndex]
        public ShapeType ShapeType => definition.shapeType;
    }
}
