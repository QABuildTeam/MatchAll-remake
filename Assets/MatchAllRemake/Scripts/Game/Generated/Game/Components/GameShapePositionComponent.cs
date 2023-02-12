//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MatchAll.Game.ShapePositionComponent shapePosition { get { return (MatchAll.Game.ShapePositionComponent)GetComponent(GameComponentsLookup.ShapePosition); } }
    public bool hasShapePosition { get { return HasComponent(GameComponentsLookup.ShapePosition); } }

    public void AddShapePosition(MatchAll.Game.V2IntPosition newPosition) {
        var index = GameComponentsLookup.ShapePosition;
        var component = (MatchAll.Game.ShapePositionComponent)CreateComponent(index, typeof(MatchAll.Game.ShapePositionComponent));
        component.position = newPosition;
        AddComponent(index, component);
    }

    public void ReplaceShapePosition(MatchAll.Game.V2IntPosition newPosition) {
        var index = GameComponentsLookup.ShapePosition;
        var component = (MatchAll.Game.ShapePositionComponent)CreateComponent(index, typeof(MatchAll.Game.ShapePositionComponent));
        component.position = newPosition;
        ReplaceComponent(index, component);
    }

    public void RemoveShapePosition() {
        RemoveComponent(GameComponentsLookup.ShapePosition);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherShapePosition;

    public static Entitas.IMatcher<GameEntity> ShapePosition {
        get {
            if (_matcherShapePosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ShapePosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherShapePosition = matcher;
            }

            return _matcherShapePosition;
        }
    }
}
