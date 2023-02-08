//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MatchAll.Game.ShapeSampleCooldownComponent shapeSampleCooldown { get { return (MatchAll.Game.ShapeSampleCooldownComponent)GetComponent(GameComponentsLookup.ShapeSampleCooldown); } }
    public bool hasShapeSampleCooldown { get { return HasComponent(GameComponentsLookup.ShapeSampleCooldown); } }

    public void AddShapeSampleCooldown(float newCooldown) {
        var index = GameComponentsLookup.ShapeSampleCooldown;
        var component = (MatchAll.Game.ShapeSampleCooldownComponent)CreateComponent(index, typeof(MatchAll.Game.ShapeSampleCooldownComponent));
        component.cooldown = newCooldown;
        AddComponent(index, component);
    }

    public void ReplaceShapeSampleCooldown(float newCooldown) {
        var index = GameComponentsLookup.ShapeSampleCooldown;
        var component = (MatchAll.Game.ShapeSampleCooldownComponent)CreateComponent(index, typeof(MatchAll.Game.ShapeSampleCooldownComponent));
        component.cooldown = newCooldown;
        ReplaceComponent(index, component);
    }

    public void RemoveShapeSampleCooldown() {
        RemoveComponent(GameComponentsLookup.ShapeSampleCooldown);
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

    static Entitas.IMatcher<GameEntity> _matcherShapeSampleCooldown;

    public static Entitas.IMatcher<GameEntity> ShapeSampleCooldown {
        get {
            if (_matcherShapeSampleCooldown == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ShapeSampleCooldown);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherShapeSampleCooldown = matcher;
            }

            return _matcherShapeSampleCooldown;
        }
    }
}
