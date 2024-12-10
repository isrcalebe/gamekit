using osu.Framework.Graphics.Sprites;
using Shapes.Game.Extensions.FontExtensions;

namespace Shapes.Game.Graphics.Sprites;

public partial class MonogramSpriteText : SpriteText
{
    public MonogramSpriteText(float size = 16.0f)
    {
        Font = ShapesFont.Monogram.With(size: size);
        Colour = Colour4.WhiteSmoke;
    }
}
