using SampleGame.Desktop;
using osu.Framework;

using var host = Host.GetSuitableDesktopHost("KebabCaseGameName", new HostOptions
{
    FriendlyGameName = "SampleGame"
});
using var game = new SampleGameDesktopGame();

host.Run(game);
