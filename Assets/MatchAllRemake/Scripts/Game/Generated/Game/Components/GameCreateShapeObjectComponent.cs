//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MatchAll.Game.CreateShapeObjectComponent createShapeObjectComponent = new MatchAll.Game.CreateShapeObjectComponent();

    public bool isCreateShapeObject {
        get { return HasComponent(GameComponentsLookup.CreateShapeObject); }
        set {
            if (value != isCreateShapeObject) {
                var index = GameComponentsLookup.CreateShapeObject;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : createShapeObjectComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherCreateShapeObject;

    public static Entitas.IMatcher<GameEntity> CreateShapeObject {
        get {
            if (_matcherCreateShapeObject == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CreateShapeObject);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCreateShapeObject = matcher;
            }

            return _matcherCreateShapeObject;
        }
    }
}