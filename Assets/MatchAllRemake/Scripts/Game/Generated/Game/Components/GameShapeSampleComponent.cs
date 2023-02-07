//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity shapeSampleEntity { get { return GetGroup(GameMatcher.ShapeSample).GetSingleEntity(); } }

    public bool isShapeSample {
        get { return shapeSampleEntity != null; }
        set {
            var entity = shapeSampleEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isShapeSample = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MatchAll.Game.ShapeSampleComponent shapeSampleComponent = new MatchAll.Game.ShapeSampleComponent();

    public bool isShapeSample {
        get { return HasComponent(GameComponentsLookup.ShapeSample); }
        set {
            if (value != isShapeSample) {
                var index = GameComponentsLookup.ShapeSample;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : shapeSampleComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherShapeSample;

    public static Entitas.IMatcher<GameEntity> ShapeSample {
        get {
            if (_matcherShapeSample == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ShapeSample);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherShapeSample = matcher;
            }

            return _matcherShapeSample;
        }
    }
}