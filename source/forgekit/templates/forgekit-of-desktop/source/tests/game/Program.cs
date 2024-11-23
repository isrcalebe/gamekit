using SampleGame.Game.Tests;
using osu.Framework;

using var host = Host.GetSuitableDesktopHost("KebabCaseGameName-visual-tests", new HostOptions
{
    PortableInstallation = true
});
using var game = new SampleGameTestBrowser();

host.Run(game);
