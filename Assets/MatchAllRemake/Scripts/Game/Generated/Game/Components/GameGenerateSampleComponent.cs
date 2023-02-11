//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MatchAll.Game.GenerateSampleComponent generateSampleComponent = new MatchAll.Game.GenerateSampleComponent();

    public bool isGenerateSample {
        get { return HasComponent(GameComponentsLookup.GenerateSample); }
        set {
            if (value != isGenerateSample) {
                var index = GameComponentsLookup.GenerateSample;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : generateSampleComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherGenerateSample;

    public static Entitas.IMatcher<GameEntity> GenerateSample {
        get {
            if (_matcherGenerateSample == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GenerateSample);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGenerateSample = matcher;
            }

            return _matcherGenerateSample;
        }
    }
}
