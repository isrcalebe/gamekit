global using osu.Framework.Allocation;
global using osu.Framework.Bindables;
global using osu.Framework.Graphics;
global using osu.Framework.Graphics.Primitives;
global using osu.Framework.Logging;
global using osu.Framework.Testing;
global using osu.Framework.Utils;
global using osuTK;
using osu.Framework.IO.Stores;
using osu.Framework.Platform;
using Shapes.Game.Resources;

namespace Shapes.Game;

public abstract partial class ShapesGameBase : osu.Framework.Game
{
    private DependencyContainer? dependencies;


    protected Storage? Storage { get; set; }

    [BackgroundDependencyLoader]
    private void load()
    {
        Resources.AddStore(new DllResourceStore(ShapesResourceAssemblyProvider.Assembly));

        addFonts();

        dependencies?.CacheAs(Storage);
    }

    private void addFonts()
    {
        AddFont(Resources, @"Fonts/Monogram/Monogram-Regular");
        AddFont(Resources, @"Fonts/Monogram/Monogram-RegularItalic");
    }

    public override void SetHost(GameHost host)
    {
        host.Window.CursorState |= CursorState.Hidden;

        base.SetHost(host);

        Storage ??= host.Storage;
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
}
