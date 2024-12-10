using FKSample.Game.Graphics.Sprites;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK.Input;

namespace FKSample.Game.Screens;

public partial class TitleScreen : Screen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren =
        [
            new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = Colour4.Green,
            },
            new MonogramSpriteText(64)
            {
                Padding = new MarginPadding(16),
                Text = "TITLE SCREEN",
                Colour = Colour4.DarkGreen,
            },
            new MonogramSpriteText(32)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "PRESS ENTER or TAP to JUMP to GAMEPLAY SCREEN",
                Colour = Colour4.DarkGreen,
            },
        ];
    }

    protected override bool OnKeyDown(KeyDownEvent e)
    {
        if (e is { Repeat: false, Key: Key.Enter })
            this.Push(new GamePlayScreen());

        return base.OnKeyDown(e);
    }

    protected override bool OnTouchDown(TouchDownEvent e)
    {
        this.Push(new GamePlayScreen());

        return base.OnTouchDown(e);
    }
}
