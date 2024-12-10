using osu.Framework.Graphics.Sprites;

namespace Shapes.Game.Graphics;

public static class ShapesFont
{
    public const float DEFAULT_FONT_SIZE = 16.0f;

    public static FontUsage Roboto => GetFont();
    public static FontUsage RobotoCondensed => GetFont(FontTypeface.RobotoCondensed);

    public static FontUsage Monogram => GetFont(FontTypeface.Monogram);

    public static FontUsage GetFont(FontTypeface typeface = FontTypeface.Roboto, float size = DEFAULT_FONT_SIZE, FontWeight weight = FontWeight.Regular, bool italics = false, bool fixedWidth = false)
    {
        var familyStr = GetFamilyString(typeface);

        return new FontUsage(familyStr, size, GetWeightString(familyStr, weight), getItalics(italics), fixedWidth);
    }

    public static string GetFamilyString(FontTypeface typeface)
    {
        return typeface.ToString();
    }

    public static string GetWeightString(string family, FontWeight weight)
    {
        return weight.ToString();
    }

    private static bool getItalics(in bool italicsRequested)
        => false;
}

public enum FontTypeface
{
    Roboto,
    RobotoCondensed,
    Monogram,
}

public enum FontWeight
{
    Thin = 100,
    ExtraLight = 200,
    Light = 300,
    Regular = 400,
    Medium = 500,
    SemiBold = 600,
    Bold = 700,
    ExtraBold = 800,
    Black = 900,
}
