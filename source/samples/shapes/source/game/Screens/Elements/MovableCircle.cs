using osu.Framework.Graphics.Shapes;
using osuTK.Input;

namespace Shapes.Game.Screens.Elements;

public partial class MovableCircle : Circle, IMovableEntity
{
    public float MaxSpeed => 1.0f;

    public float Acceleration => 0.0020f;

    public float Deceleration => 1.0f;

    private Vector2 speed = Vector2.Zero;
    private Vector2 inputDirection = Vector2.Zero;

    public Vector2 Speed => speed;

    public Vector2 InputDirection => inputDirection;

    public bool IsMoving => speed.LengthSquared > 0;

    public bool LockInput { get; set; } = false;

    protected override void Update()
    {
        base.Update();

        updateInput();
        updateSpeed();
        updatePosition();
    }

    public void ResetPosition()
    {
        Position = Vector2.Zero;
        speed = Vector2.Zero;
        inputDirection = Vector2.Zero;
    }

    private void updateInput()
    {
        if (LockInput) return;

        inputDirection = Vector2.Zero;

        var keyboard = GetContainingInputManager().CurrentState.Keyboard;

        if (keyboard.Keys.IsPressed(Key.A))
            inputDirection.X -= 1;
        if (keyboard.Keys.IsPressed(Key.D))
            inputDirection.X += 1;
        if (keyboard.Keys.IsPressed(Key.W))
            inputDirection.Y -= 1;
        if (keyboard.Keys.IsPressed(Key.S))
            inputDirection.Y += 1;

        if (inputDirection.LengthSquared > 0)
            inputDirection = inputDirection.Normalized();
    }

    private void updateSpeed()
    {
        speed += inputDirection * Acceleration * (float)Clock.ElapsedFrameTime;

        if (inputDirection.LengthSquared == 0 && speed.LengthSquared > 0)
        {
            speed -= speed.Normalized() * Acceleration * Deceleration * (float)Clock.ElapsedFrameTime;

            if (speed.Length < 0.01f)
                speed = Vector2.Zero;
        }

        if (speed.LengthSquared > (MaxSpeed * MaxSpeed))
            speed = speed.Normalized() * MaxSpeed;
    }

    private void updatePosition()
    {
        Position += speed * (float)Clock.ElapsedFrameTime;
    }
}

public interface IMovableEntity
{
    float MaxSpeed { get; }

    float Acceleration { get; }

    float Deceleration { get; }

    bool IsMoving { get; }

    Vector2 Speed { get; }

    Vector2 Position { get; }
}
