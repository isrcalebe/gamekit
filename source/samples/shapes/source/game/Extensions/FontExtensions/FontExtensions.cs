using osu.Framework.Graphics.Sprites;
using Shapes.Game.Graphics;

namespace Shapes.Game.Extensions.FontExtensions;

public static class FontExtensions
{
    public static FontUsage With(this FontUsage usage, FontTypeface? typeface = null, float? size = null, FontWeight? weight = null, bool? italics = null, bool? fixedWidth = null)
    {
        var familyStr = typeface != null ? ShapesFont.GetFamilyString(typeface.Value) : usage.Family;
        var weightStr = weight != null ? ShapesFont.GetWeightString(familyStr, weight.Value) : usage.Weight;

        return usage.With(familyStr, size, weightStr, italics, fixedWidth);
    }
}
