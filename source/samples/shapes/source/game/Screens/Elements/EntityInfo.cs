using osu.Framework.Graphics.Containers;
using FKSample.Game.Graphics.Sprites;

namespace FKSample.Game.Screens.Elements;

public partial class EntityInfo : VisibilityContainer
{
    private FillFlowContainer? texts;

    private MonogramSpriteText? speedInfo, positionInfo;

    public EntityInfo()
    {
        AutoSizeAxes = Axes.Both;
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        AddInternal(texts = new FillFlowContainer
        {
            AutoSizeAxes = Axes.Both,
            Direction = FillDirection.Vertical,
            Padding = new MarginPadding(16.0f),
            Children =
            [
                speedInfo = new MonogramSpriteText(24.0f),
                positionInfo = new MonogramSpriteText(24.0f),
            ]
        });
    }

    public void SetInfo(IMovableEntity entity)
    {
        speedInfo!.Text = $"Speed: ({entity.Speed.X:0.00}, {entity.Speed.Y:0.00})";
        positionInfo!.Text = $"Position: ({entity.Position.X:0.00}, {entity.Position.Y:0.00})";
    }

    protected override void PopIn()
    {
        speedInfo?.FadeIn(100.0d);
        positionInfo?.FadeIn(100.0d);
    }

    protected override void PopOut()
    {
        speedInfo?.Delay(500.0d).Then().FadeOut(700.0d);
        positionInfo?.Delay(500.0d).Then().FadeOut(700.0d);
    }
}
