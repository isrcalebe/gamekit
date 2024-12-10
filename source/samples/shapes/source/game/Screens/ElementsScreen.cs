using System;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using FKSample.Game.Graphics.UI;
using FKSample.Game.Input.Bindings;
using FKSample.Game.Screens.Elements;

namespace FKSample.Game.Screens;

public partial class ElementsScreen : GameScreen, IKeyBindingHandler<GameAction>
{
    private TrackingCircle? trackingCircle;
    private RotatingBox? rotatingBox;
    private MovableCircle? movableCircle;

    private EntityInfo? entityInfo;

    private AlertText? alertText;

    private Bindable<bool> showEntityInfo = new();
    private bool toggleEntityInfo;

    [BackgroundDependencyLoader]
    private void load()
    {
        AddRangeInternal(
        [
            rotatingBox = new RotatingBox
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(128.0f),
                EdgeSmoothness = new Vector2(2.0f),
                Colour = Colour4.FromHex("#0FC2C0")
            },
            movableCircle = new MovableCircle
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(128.0f),
                Position = new Vector2(0, -128.0f),
                Colour = Colour4.FromHex("#E02041")
            },
            entityInfo = [],
            trackingCircle = new TrackingCircle
            {
                Colour = Colour4.FromHex("#BDE038")
            },
            alertText = new AlertText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            }
        ]);

        entityInfo.Hide();
        showEntityInfo.BindValueChanged(onShowEntityInfoChanged, false);
    }

    protected override void Update()
    {
        base.Update();

        entityInfo?.SetInfo(movableCircle!);

        if (!toggleEntityInfo)
            showEntityInfo.Value = movableCircle!.IsMoving;
    }

    private void onShowEntityInfoChanged(ValueChangedEvent<bool> e)
    {
        if (e.NewValue)
            entityInfo?.Show();
        else
            entityInfo?.Hide();
    }

    public bool OnPressed(KeyBindingPressEvent<GameAction> e)
    {
        switch (e.Action)
        {
            case GameAction.ToggleEntityInfo:
                toggleEntityInfo = !toggleEntityInfo;

                if (toggleEntityInfo)
                    entityInfo?.Show();
                else
                    entityInfo?.Hide();

                alertText?.Alert($"Entity info is now {(toggleEntityInfo ? "visible" : "auto-hidden")}.");
                return true;

            case GameAction.ResetPosition:
                movableCircle?.ResetPosition();
                alertText?.Alert("The circle's position has been reset.");
                return true;
        }

        return false;
    }

    public void OnReleased(KeyBindingReleaseEvent<GameAction> e)
    {
    }
}
