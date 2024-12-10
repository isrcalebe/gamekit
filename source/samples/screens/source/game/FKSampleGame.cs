using osu.Framework.Screens;
using FKSample.Game.Input.Bindings;
using FKSample.Game.Screens;

namespace FKSample.Game;

public partial class FKSampleGame : FKSampleGameBase
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

        screens.Push(new LogoScreen());
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
}
