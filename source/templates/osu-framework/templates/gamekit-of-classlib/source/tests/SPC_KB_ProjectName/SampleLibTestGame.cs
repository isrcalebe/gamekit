namespace SampleLib.Tests;

public partial class SampleLibTestGame : osu.Framework.Game
{
    private DependencyContainer? dependencies;

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
}
