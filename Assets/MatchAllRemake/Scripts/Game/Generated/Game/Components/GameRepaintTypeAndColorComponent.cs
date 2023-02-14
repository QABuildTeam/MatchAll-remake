//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity repaintTypeAndColorEntity { get { return GetGroup(GameMatcher.RepaintTypeAndColor).GetSingleEntity(); } }
    public MatchAll.Game.RepaintTypeAndColorComponent repaintTypeAndColor { get { return repaintTypeAndColorEntity.repaintTypeAndColor; } }
    public bool hasRepaintTypeAndColor { get { return repaintTypeAndColorEntity != null; } }

    public GameEntity SetRepaintTypeAndColor(MatchAll.ShapeDefinition newShapeDefinition) {
        if (hasRepaintTypeAndColor) {
            throw new Entitas.EntitasException("Could not set RepaintTypeAndColor!\n" + this + " already has an entity with MatchAll.Game.RepaintTypeAndColorComponent!",
                "You should check if the context already has a repaintTypeAndColorEntity before setting it or use context.ReplaceRepaintTypeAndColor().");
        }
        var entity = CreateEntity();
        entity.AddRepaintTypeAndColor(newShapeDefinition);
        return entity;
    }

    public void ReplaceRepaintTypeAndColor(MatchAll.ShapeDefinition newShapeDefinition) {
        var entity = repaintTypeAndColorEntity;
        if (entity == null) {
            entity = SetRepaintTypeAndColor(newShapeDefinition);
        } else {
            entity.ReplaceRepaintTypeAndColor(newShapeDefinition);
        }
    }

    public void RemoveRepaintTypeAndColor() {
        repaintTypeAndColorEntity.Destroy();
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

    public MatchAll.Game.RepaintTypeAndColorComponent repaintTypeAndColor { get { return (MatchAll.Game.RepaintTypeAndColorComponent)GetComponent(GameComponentsLookup.RepaintTypeAndColor); } }
    public bool hasRepaintTypeAndColor { get { return HasComponent(GameComponentsLookup.RepaintTypeAndColor); } }

    public void AddRepaintTypeAndColor(MatchAll.ShapeDefinition newShapeDefinition) {
        var index = GameComponentsLookup.RepaintTypeAndColor;
        var component = (MatchAll.Game.RepaintTypeAndColorComponent)CreateComponent(index, typeof(MatchAll.Game.RepaintTypeAndColorComponent));
        component.shapeDefinition = newShapeDefinition;
        AddComponent(index, component);
    }

    public void ReplaceRepaintTypeAndColor(MatchAll.ShapeDefinition newShapeDefinition) {
        var index = GameComponentsLookup.RepaintTypeAndColor;
        var component = (MatchAll.Game.RepaintTypeAndColorComponent)CreateComponent(index, typeof(MatchAll.Game.RepaintTypeAndColorComponent));
        component.shapeDefinition = newShapeDefinition;
        ReplaceComponent(index, component);
    }

    public void RemoveRepaintTypeAndColor() {
        RemoveComponent(GameComponentsLookup.RepaintTypeAndColor);
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

    static Entitas.IMatcher<GameEntity> _matcherRepaintTypeAndColor;

    public static Entitas.IMatcher<GameEntity> RepaintTypeAndColor {
        get {
            if (_matcherRepaintTypeAndColor == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RepaintTypeAndColor);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRepaintTypeAndColor = matcher;
            }

            return _matcherRepaintTypeAndColor;
        }
    }
}
