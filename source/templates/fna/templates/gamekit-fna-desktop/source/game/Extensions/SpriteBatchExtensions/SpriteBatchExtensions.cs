using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SampleGame.Game.Extensions.SpriteBatchExtensions;

public static class SpriteBatchExtensions
{
    public static void DrawEx(
        this SpriteBatch self,
        Texture2D texture,
        Vector2? position = null,
        float? rotation = 0.0f,
        Vector2? origin = null,
        Vector2? scale = null,
        Rectangle? source = null,
        Color? color = null,
        SpriteEffects? effects = null,
        float? layerDepth = 0.0f
    )
    {
        self.Draw(
            texture,
            position ?? Vector2.Zero,
            source,
            color ?? Color.White,
            rotation ?? 0.0f,
            origin ?? Vector2.Zero,
            scale ?? Vector2.One,
            effects ?? SpriteEffects.None,
            layerDepth ?? 0.0f
        );
    }
}
