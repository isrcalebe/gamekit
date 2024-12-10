using System.Collections.Generic;
using osu.Framework.Input.Bindings;

namespace FKSample.Game.Input.Bindings;

public partial class GameKeyBindingContainer : KeyBindingContainer<GameAction>
{
    public override IEnumerable<IKeyBinding> DefaultKeyBindings => [
        new KeyBinding(new[] { InputKey.R }, GameAction.ResetPosition),
        new KeyBinding(new[] { InputKey.P }, GameAction.ToggleEntityInfo)
    ];
}

public enum GameAction
{
    ResetPosition,
    ToggleEntityInfo
}
