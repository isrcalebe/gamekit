using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using FKSample.Game.Graphics.Sprites;

namespace FKSample.Game.Graphics.UI;

public partial class AlertText : CompositeDrawable
{
    private SpriteText? text;

    private Box? background;

    public AlertText()
    {
        RelativeSizeAxes = Axes.X;
        AutoSizeAxes = Axes.Y;

        Masking = true;
        CornerRadius = 5.0f;
        Alpha = 0.0f;

        InternalChildren =
        [
            background = new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = Colour4.Black,
                Alpha = 0.75f,
            },
            text = new MonogramSpriteText(40.0f)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Padding = new MarginPadding(16.0f),

            },
        ];
    }

    public void Alert(string message)
    {
        text!.Text = message;
        this.FadeIn(100.0d).Delay(500.0d).Then().FadeOut(300.0d);
    }
}
