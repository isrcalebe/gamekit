using osu.Framework.Graphics.Sprites;
using FKSample.Game.Graphics;

namespace FKSample.Game.Extensions.FontExtensions;

public static class FontExtensions
{
    public static FontUsage With(this FontUsage usage, FontTypeface? typeface = null, float? size = null, FontWeight? weight = null, bool? italics = null, bool? fixedWidth = null)
    {
        var familyStr = typeface != null ? FKSampleFont.GetFamilyString(typeface.Value) : usage.Family;
        var weightStr = weight != null ? FKSampleFont.GetWeightString(familyStr, weight.Value) : usage.Weight;

        return usage.With(familyStr, size, weightStr, italics, fixedWidth);
    }
}
