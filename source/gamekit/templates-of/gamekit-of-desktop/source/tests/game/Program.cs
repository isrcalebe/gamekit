using SampleGame.Game.Tests;
using osu.Framework;

using var host = Host.GetSuitableDesktopHost("SPC_KB_ProjectName-visual-tests", new HostOptions
{
    PortableInstallation = true
});
using var game = new SampleGameTestBrowser();

host.Run(game);
