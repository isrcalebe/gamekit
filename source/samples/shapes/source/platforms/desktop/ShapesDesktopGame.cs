using System.Reflection;
using Shapes.Game;
using osu.Framework.Platform;

namespace Shapes.Desktop;

internal sealed partial class ShapesDesktopGame : ShapesGame
{
    public override void SetHost(GameHost host)
    {
        base.SetHost(host);

        var iconStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), "Shapes.ico");
        if (iconStream != null)
            host.Window?.SetIconFromStream(iconStream);
    }
}
