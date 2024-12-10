using osu.Framework.Graphics.Shapes;

namespace FKSample.Game.Screens.Elements;

public partial class RotatingBox : Box
{
    private readonly Bindable<double> duration = new(4000.0d);

    /// <summary>
    ///
    /// </summary>
    public double Duration
    {
        get => duration.Value;
        set => duration.Value = value;
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        duration.BindValueChanged(onDurationChanged, true);
    }

    private void onDurationChanged(ValueChangedEvent<double> e)
    {
        ClearTransforms();

        this.RotateTo(0.0f, 0.0d).Then()
            .RotateTo(360.0f, e.NewValue).Loop();
    }
}
