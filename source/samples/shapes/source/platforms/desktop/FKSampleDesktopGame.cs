using System.Reflection;
using FKSample.Game;
using osu.Framework.Platform;

namespace FKSample.Desktop;

internal sealed partial class FKSampleDesktopGame : FKSampleGame
{
    public override void SetHost(GameHost host)
    {
        base.SetHost(host);

        var iconStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), "fk-sample.ico");
        if (iconStream != null)
            host.Window?.SetIconFromStream(iconStream);
    }
}
