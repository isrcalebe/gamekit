using osu.Framework.Graphics.Sprites;

namespace FKSample.Game.Graphics.Sprites;

public partial class MonogramSpriteText : SpriteText
{
    public MonogramSpriteText(float size = 16.0f)
    {
        Font = FKSampleFont.Monogram.With(size: size);
        Colour = Colour4.WhiteSmoke;
    }
}
