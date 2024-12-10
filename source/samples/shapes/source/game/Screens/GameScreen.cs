using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using Shapes.Game.Graphics;
using Shapes.Game.Graphics.Sprites;

namespace Shapes.Game.Screens;

public partial class GameScreen : Screen
{
    private Bindable<ColourInfo> backgroundColor = new(ColourInfo.GradientVertical(Colour4.FromHex("#015958"), Colour4.FromHex("#023535")));

    protected ColourInfo BackgroundColour
    {
        get => backgroundColor.Value;
        set => backgroundColor.Value = value;
    }

    protected Box? Background { get; private set; }

    [BackgroundDependencyLoader]
    private void load()
    {
        AddInternal(Background = new Box
        {
            RelativeSizeAxes = Axes.Both,
        });

        AddInternal(new FillFlowContainer
        {
            Anchor = Anchor.BottomLeft,
            Origin = Anchor.BottomLeft,
            AutoSizeAxes = Axes.Both,
            Direction = FillDirection.Vertical,
            Padding = new MarginPadding(16),
            Children =
            [
                new MonogramSpriteText
                {
                    Text = "WASD to move",
                },
                new MonogramSpriteText
                {
                    Text = "R to reset position",
                },
                new MonogramSpriteText
                {
                    Text = "P to toggle entity visibility mode",
                },
            ]
        });

        backgroundColor.BindValueChanged(e => Background.Colour = e.NewValue, true);
    }
}
