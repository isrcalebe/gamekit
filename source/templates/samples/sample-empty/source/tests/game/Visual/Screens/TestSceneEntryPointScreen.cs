using osu.Framework.Screens;
using SampleGame.Game.Screens;

namespace SampleGame.Game.Tests.Visual.Screens;

public partial class TestSceneEntryPointScreen : SampleGameTestScene
{
    private ScreenStack? screens;

    [BackgroundDependencyLoader]
    private void load()
    {
        Child = screens = new ScreenStack();

        AddStep("push screen a", () => screens.Push(new EntryPointScreenA()));
        AddStep("push screen b", () => screens.Push(new EntryPointScreenB()));
    }
}
