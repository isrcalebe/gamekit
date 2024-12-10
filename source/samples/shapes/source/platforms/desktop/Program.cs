using Shapes.Desktop;
using osu.Framework;

using var host = Host.GetSuitableDesktopHost("shapes", new HostOptions
{
    FriendlyGameName = "SHAPES - ForgeKit Samples"
});
using var game = new ShapesDesktopGame();

host.Run(game);
