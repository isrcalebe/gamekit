using FKSample.Desktop;
using osu.Framework;

using var host = Host.GetSuitableDesktopHost("forgekit-samples-shapes", new HostOptions
{
    FriendlyGameName = "SHAPES - ForgeKit Samples"
});
using var game = new FKSampleDesktopGame();

host.Run(game);
