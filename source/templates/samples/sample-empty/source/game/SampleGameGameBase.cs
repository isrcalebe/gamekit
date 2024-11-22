global using osu.Framework.Allocation;
global using osu.Framework.Bindables;
global using osu.Framework.Graphics;
global using osu.Framework.Graphics.Primitives;
global using osu.Framework.Logging;
global using osu.Framework.Testing;
global using osu.Framework.Utils;
global using osuTK;
#if (PreferNearestTextureFiltering)
using osu.Framework.Graphics.Textures;
#endif
using osu.Framework.IO.Stores;
using osu.Framework.Platform;
using SampleGame.Game.Configuration;
using SampleGame.Game.Resources;

namespace SampleGame.Game;

public abstract partial class SampleGameGameBase : osu.Framework.Game
{
    private DependencyContainer? dependencies;
#if (PreferNearestTextureFiltering)

    protected override TextureFilteringMode DefaultTextureFilteringMode => TextureFilteringMode.Nearest;
#endif

    protected SampleGameConfigManager? LocalConfig { get; private set; }

    protected Storage? Storage { get; set; }

    [BackgroundDependencyLoader]
    private void load()
    {
        Resources.AddStore(new DllResourceStore(SampleGameResourceAssemblyProvider.Assembly));

        dependencies?.CacheAs(Storage);
        dependencies?.CacheAs(LocalConfig);
    }

    public override void SetHost(GameHost host)
    {
        base.SetHost(host);

        Storage ??= host.Storage;
        LocalConfig = new SampleGameConfigManager(Storage);
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
}
