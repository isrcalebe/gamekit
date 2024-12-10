using FKSample.Game.Graphics.Sprites;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK.Input;

namespace FKSample.Game.Screens;

public partial class GamePlayScreen : Screen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren =
        [
            new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = Colour4.Purple,
            },
            new MonogramSpriteText(64)
            {
                Padding = new MarginPadding(16),
                Text = "GAMEPLAY SCREEN",
                Colour = Colour4.FromHex("#CC3333"),
            },
            new MonogramSpriteText(32)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "PRESS ENTER or TAP to JUMP to ENDING SCREEN",
                Colour = Colour4.FromHex("#CC3333"),
            },
        ];
    }

    protected override bool OnKeyDown(KeyDownEvent e)
    {
        if (e is { Repeat: false, Key: Key.Enter })
            this.Push(new EndingScreen());

        return base.OnKeyDown(e);
    }

    protected override bool OnTouchDown(TouchDownEvent e)
    {
        this.Push(new EndingScreen());

        return base.OnTouchDown(e);
    }
}
