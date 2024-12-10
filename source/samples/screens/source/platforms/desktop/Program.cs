using FKSample.Desktop;
using osu.Framework;

using var host = Host.GetSuitableDesktopHost("forgekit-samples-screens", new HostOptions
{
    FriendlyGameName = "SCREENS - ForgeKit Samples"
});
using var game = new FKSampleDesktopGame();

host.Run(game);
