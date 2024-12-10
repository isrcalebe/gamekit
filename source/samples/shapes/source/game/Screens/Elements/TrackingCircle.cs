using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;

namespace FKSample.Game.Screens.Elements;

public partial class TrackingCircle : CompositeDrawable
{
    private Circle? cursor;

    public TrackingCircle()
    {
        RelativeSizeAxes = Axes.Both;

        InternalChild = cursor = new Circle
        {
            Origin = Anchor.Centre,
            Size = new(16.0f),
            Colour = Colour4.FromHex("#B2BEBF"),
        };
    }

    protected override bool OnMouseMove(MouseMoveEvent e)
    {
        cursor.MoveTo(e.MousePosition);

        return base.OnMouseMove(e);
    }
}
