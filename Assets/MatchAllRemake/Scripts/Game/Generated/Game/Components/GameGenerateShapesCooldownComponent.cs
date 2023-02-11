//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity generateShapesCooldownEntity { get { return GetGroup(GameMatcher.GenerateShapesCooldown).GetSingleEntity(); } }
    public MatchAll.Game.GenerateShapesCooldownComponent generateShapesCooldown { get { return generateShapesCooldownEntity.generateShapesCooldown; } }
    public bool hasGenerateShapesCooldown { get { return generateShapesCooldownEntity != null; } }

    public GameEntity SetGenerateShapesCooldown(float newCooldown) {
        if (hasGenerateShapesCooldown) {
            throw new Entitas.EntitasException("Could not set GenerateShapesCooldown!\n" + this + " already has an entity with MatchAll.Game.GenerateShapesCooldownComponent!",
                "You should check if the context already has a generateShapesCooldownEntity before setting it or use context.ReplaceGenerateShapesCooldown().");
        }
        var entity = CreateEntity();
        entity.AddGenerateShapesCooldown(newCooldown);
        return entity;
    }

    public void ReplaceGenerateShapesCooldown(float newCooldown) {
        var entity = generateShapesCooldownEntity;
        if (entity == null) {
            entity = SetGenerateShapesCooldown(newCooldown);
        } else {
            entity.ReplaceGenerateShapesCooldown(newCooldown);
        }
    }

    public void RemoveGenerateShapesCooldown() {
        generateShapesCooldownEntity.Destroy();
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

    public MatchAll.Game.GenerateShapesCooldownComponent generateShapesCooldown { get { return (MatchAll.Game.GenerateShapesCooldownComponent)GetComponent(GameComponentsLookup.GenerateShapesCooldown); } }
    public bool hasGenerateShapesCooldown { get { return HasComponent(GameComponentsLookup.GenerateShapesCooldown); } }

    public void AddGenerateShapesCooldown(float newCooldown) {
        var index = GameComponentsLookup.GenerateShapesCooldown;
        var component = (MatchAll.Game.GenerateShapesCooldownComponent)CreateComponent(index, typeof(MatchAll.Game.GenerateShapesCooldownComponent));
        component.cooldown = newCooldown;
        AddComponent(index, component);
    }

    public void ReplaceGenerateShapesCooldown(float newCooldown) {
        var index = GameComponentsLookup.GenerateShapesCooldown;
        var component = (MatchAll.Game.GenerateShapesCooldownComponent)CreateComponent(index, typeof(MatchAll.Game.GenerateShapesCooldownComponent));
        component.cooldown = newCooldown;
        ReplaceComponent(index, component);
    }

    public void RemoveGenerateShapesCooldown() {
        RemoveComponent(GameComponentsLookup.GenerateShapesCooldown);
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

    static Entitas.IMatcher<GameEntity> _matcherGenerateShapesCooldown;

    public static Entitas.IMatcher<GameEntity> GenerateShapesCooldown {
        get {
            if (_matcherGenerateShapesCooldown == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GenerateShapesCooldown);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGenerateShapesCooldown = matcher;
            }

            return _matcherGenerateShapesCooldown;
        }
    }
}