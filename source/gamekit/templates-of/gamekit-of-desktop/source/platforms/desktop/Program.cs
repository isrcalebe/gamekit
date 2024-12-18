using SampleGame.Desktop;
using osu.Framework;

using var host = Host.GetSuitableDesktopHost("SPC_KB_ProjectName", new HostOptions
{
    FriendlyGameName = "SampleGame"
});
using var game = new SampleGameDesktopGame();

host.Run(game);
