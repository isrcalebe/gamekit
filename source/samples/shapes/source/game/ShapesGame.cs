using osu.Framework.Screens;
using Shapes.Game.Input.Bindings;
using Shapes.Game.Screens;

namespace Shapes.Game;

public partial class ShapesGame : ShapesGameBase
{
    private DependencyContainer? dependencies;

    private ScreenStack? screens;

    [BackgroundDependencyLoader]
    private void load()
    {
        Add(new GameKeyBindingContainer
        {
            Child = screens = new ScreenStack()
        });

        screens.Push(new ElementsScreen());
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
}
