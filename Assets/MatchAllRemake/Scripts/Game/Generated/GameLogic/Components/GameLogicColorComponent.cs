//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameLogicEntity {

    public MatchAll.Game.ColorComponent color { get { return (MatchAll.Game.ColorComponent)GetComponent(GameLogicComponentsLookup.Color); } }
    public bool hasColor { get { return HasComponent(GameLogicComponentsLookup.Color); } }

    public void AddColor(int newColorIndex) {
        var index = GameLogicComponentsLookup.Color;
        var component = (MatchAll.Game.ColorComponent)CreateComponent(index, typeof(MatchAll.Game.ColorComponent));
        component.colorIndex = newColorIndex;
        AddComponent(index, component);
    }

    public void ReplaceColor(int newColorIndex) {
        var index = GameLogicComponentsLookup.Color;
        var component = (MatchAll.Game.ColorComponent)CreateComponent(index, typeof(MatchAll.Game.ColorComponent));
        component.colorIndex = newColorIndex;
        ReplaceComponent(index, component);
    }

    public void RemoveColor() {
        RemoveComponent(GameLogicComponentsLookup.Color);
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
public sealed partial class GameLogicMatcher {

    static Entitas.IMatcher<GameLogicEntity> _matcherColor;

    public static Entitas.IMatcher<GameLogicEntity> Color {
        get {
            if (_matcherColor == null) {
                var matcher = (Entitas.Matcher<GameLogicEntity>)Entitas.Matcher<GameLogicEntity>.AllOf(GameLogicComponentsLookup.Color);
                matcher.componentNames = GameLogicComponentsLookup.componentNames;
                _matcherColor = matcher;
            }

            return _matcherColor;
        }
    }
}