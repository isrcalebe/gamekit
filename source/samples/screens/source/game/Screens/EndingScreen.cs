using FKSample.Game.Graphics.Sprites;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK.Input;

namespace FKSample.Game.Screens;

public partial class EndingScreen : Screen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren =
        [
            new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = Colour4.Blue,
            },
            new MonogramSpriteText(64)
            {
                Padding = new MarginPadding(16),
                Text = "ENDING SCREEN",
                Colour = Colour4.DarkBlue,
            },
            new MonogramSpriteText(32)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "PRESS ENTER or TAP to JUMP to ENDING SCREEN",
                Colour = Colour4.DarkBlue,
            },
        ];
    }

    protected override bool OnKeyDown(KeyDownEvent e)
    {
        if (e is { Repeat: false, Key: Key.Enter })
            this.Push(new TitleScreen());

        return base.OnKeyDown(e);
    }

    protected override bool OnTouchDown(TouchDownEvent e)
    {
        this.Push(new TitleScreen());

        return base.OnTouchDown(e);
    }
}
