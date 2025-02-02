using osu.Framework;
using SampleLib.Tests;

using var host = Host.GetSuitableDesktopHost("SPC_KB_ProjectName-visual-tests", new HostOptions
{
    PortableInstallation = true
});
using var game = new SampleLibTestBrowser();

host.Run(game);
