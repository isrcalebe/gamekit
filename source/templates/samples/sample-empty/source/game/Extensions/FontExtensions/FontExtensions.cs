using osu.Framework.Graphics.Sprites;
using SampleGame.Game.Graphics;

namespace SampleGame.Game.Extensions.FontExtensions;

public static class FontExtensions
{
    public static FontUsage With(this FontUsage usage, FontTypeface? typeface = null, float? size = null, FontWeight? weight = null, bool? italics = null, bool? fixedWidth = null)
    {
        var familyStr = typeface != null ? SampleGameFont.GetFamilyString(typeface.Value) : usage.Family;
        var weightStr = weight != null ? SampleGameFont.GetWeightString(familyStr, weight.Value) : usage.Weight;

        return usage.With(familyStr, size, weightStr, italics, fixedWidth);
    }
}
