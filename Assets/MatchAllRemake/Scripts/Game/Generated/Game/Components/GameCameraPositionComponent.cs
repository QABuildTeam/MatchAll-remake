//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MatchAll.Game.CameraPositionComponent cameraPosition { get { return (MatchAll.Game.CameraPositionComponent)GetComponent(GameComponentsLookup.CameraPosition); } }
    public bool hasCameraPosition { get { return HasComponent(GameComponentsLookup.CameraPosition); } }

    public void AddCameraPosition(UnityEngine.Vector2 newPosition) {
        var index = GameComponentsLookup.CameraPosition;
        var component = (MatchAll.Game.CameraPositionComponent)CreateComponent(index, typeof(MatchAll.Game.CameraPositionComponent));
        component.position = newPosition;
        AddComponent(index, component);
    }

    public void ReplaceCameraPosition(UnityEngine.Vector2 newPosition) {
        var index = GameComponentsLookup.CameraPosition;
        var component = (MatchAll.Game.CameraPositionComponent)CreateComponent(index, typeof(MatchAll.Game.CameraPositionComponent));
        component.position = newPosition;
        ReplaceComponent(index, component);
    }

    public void RemoveCameraPosition() {
        RemoveComponent(GameComponentsLookup.CameraPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherCameraPosition;

    public static Entitas.IMatcher<GameEntity> CameraPosition {
        get {
            if (_matcherCameraPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CameraPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCameraPosition = matcher;
            }

            return _matcherCameraPosition;
        }
    }
}
