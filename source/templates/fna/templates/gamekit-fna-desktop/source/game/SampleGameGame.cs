using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleGame.Game.Extensions.SpriteBatchExtensions;

namespace SampleGame.Game;

public class SampleGameGame : SampleGameGameBase
{
    private Texture2D? texture;
    private Vector2 position;
    private float rotation;

    protected override void LoadContent()
    {
        texture = Textures.Fetch("resx://Textures/DotnetLogo.png");
        position = new Vector2(
            GraphicsDeviceManager.PreferredBackBufferWidth / 2.0f,
            GraphicsDeviceManager.PreferredBackBufferHeight / 2.0f);

        base.LoadContent();
    }

    protected override void UnloadContent()
    {
        texture?.Dispose();

        base.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        rotation += 2.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        SpriteBatch?.Begin();
        SpriteBatch?.DrawEx(texture!, position, scale: Vector2.One / 2.0f, origin: new Vector2(texture!.Width / 2.0f, texture!.Height / 2.0f), rotation: rotation);
        SpriteBatch?.End();

        base.Draw(gameTime);
    }
}
