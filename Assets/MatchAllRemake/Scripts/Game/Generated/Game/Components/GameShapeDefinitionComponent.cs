//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MatchAll.Game.ShapeDefinitionComponent shapeDefinition { get { return (MatchAll.Game.ShapeDefinitionComponent)GetComponent(GameComponentsLookup.ShapeDefinition); } }
    public bool hasShapeDefinition { get { return HasComponent(GameComponentsLookup.ShapeDefinition); } }

    public void AddShapeDefinition(MatchAll.ShapeDefinition newDefinition) {
        var index = GameComponentsLookup.ShapeDefinition;
        var component = (MatchAll.Game.ShapeDefinitionComponent)CreateComponent(index, typeof(MatchAll.Game.ShapeDefinitionComponent));
        component.definition = newDefinition;
        AddComponent(index, component);
    }

    public void ReplaceShapeDefinition(MatchAll.ShapeDefinition newDefinition) {
        var index = GameComponentsLookup.ShapeDefinition;
        var component = (MatchAll.Game.ShapeDefinitionComponent)CreateComponent(index, typeof(MatchAll.Game.ShapeDefinitionComponent));
        component.definition = newDefinition;
        ReplaceComponent(index, component);
    }

    public void RemoveShapeDefinition() {
        RemoveComponent(GameComponentsLookup.ShapeDefinition);
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

    static Entitas.IMatcher<GameEntity> _matcherShapeDefinition;

    public static Entitas.IMatcher<GameEntity> ShapeDefinition {
        get {
            if (_matcherShapeDefinition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ShapeDefinition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherShapeDefinition = matcher;
            }

            return _matcherShapeDefinition;
        }
    }
}
