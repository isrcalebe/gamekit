using System.Reflection;
using SampleGame.Game;
using osu.Framework.Platform;

namespace SampleGame.Desktop;

internal sealed partial class SampleGameDesktopGame : SampleGameGame
{
    public override void SetHost(GameHost host)
    {
        base.SetHost(host);

        var iconStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), "SampleGame.ico");
        if (iconStream != null)
            host.Window?.SetIconFromStream(iconStream);
    }
}
