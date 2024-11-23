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
#if (CMP_HasFonts)

        addFonts();
#endif

        dependencies?.CacheAs(Storage);
        dependencies?.CacheAs(LocalConfig);
    }
#if (CMP_HasFonts)

    private void addFonts()
    {
#if (IncludeFontInter)
        foreach (var weight in new[] { "Thin", "ExtraLight", "Light", "Regular", "Medium", "SemiBold", "Bold", "Black" })
        {
            AddFont(Resources, $@"Fonts/Inter/Inter-{weight}");
            AddFont(Resources, $@"Fonts/Inter/Inter-{weight}Italic");
        }
#endif
#if (IncludeFontMonogram)

        AddFont(Resources, @"Fonts/Monogram/Monogram-Regular");
        AddFont(Resources, @"Fonts/Monogram/Monogram-RegularItalic");
#endif
#if (IncludeFontSMW)

        AddFont(Resources, @"Fonts/SMW/SMW-Regular");
        AddFont(Resources, @"Fonts/SMW/SMW-RegularItalic");
        AddFont(Resources, @"Fonts/SMW/SMW-Bold");
        AddFont(Resources, @"Fonts/SMW/SMW-BoldItalic");
#endif
    }
#endif

    public override void SetHost(GameHost host)
    {
        base.SetHost(host);

        Storage ??= host.Storage;
        LocalConfig = new SampleGameConfigManager(Storage);
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
}
