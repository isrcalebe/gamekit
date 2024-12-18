using osu.Framework.Screens;
using SampleGame.Game.Configuration.Settings;
using SampleGame.Game.Screens;

namespace SampleGame.Game;

public partial class SampleGameGame : SampleGameGameBase
{
    private DependencyContainer? dependencies;

    private ScreenStack? screens;

    [BackgroundDependencyLoader]
    private void load()
    {
        Add(screens = new ScreenStack());

        var entryPoint = LocalConfig?.Get<ScreenEntryPoint>(SampleGameSetting.ScreenEntryPoint);

        switch (entryPoint)
        {
            case ScreenEntryPoint.ScreenA:
                screens.Push(new EntryPointScreenA());
                break;

            case ScreenEntryPoint.ScreenB:
                screens.Push(new EntryPointScreenB());
                break;

            default:
                screens.Push(new EntryPointScreenA());
                break;
        }
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
}
