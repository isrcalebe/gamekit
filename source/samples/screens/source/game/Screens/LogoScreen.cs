using FKSample.Game.Graphics.Sprites;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;

namespace FKSample.Game.Screens;

public partial class LogoScreen : Screen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren =
        [
            new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = Colour4.FromHex("#F5F5F5"),
            },
            new MonogramSpriteText(64)
            {
                Padding = new MarginPadding(16),
                Text = "TITLE SCREEN",
                Colour = Colour4.LightGray,
            },
            new MonogramSpriteText(32)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "WAIT for 2 SECONDS...",
                Colour = Colour4.Gray,
            },
        ];
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();

        Scheduler.AddDelayed(() => this.Push(new TitleScreen()), 2000);
    }
}
