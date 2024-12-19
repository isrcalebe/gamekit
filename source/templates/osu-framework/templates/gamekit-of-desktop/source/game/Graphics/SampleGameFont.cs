using osu.Framework.Graphics.Sprites;

namespace SampleGame.Game.Graphics;

public static class SampleGameFont
{
    public const float DEFAULT_FONT_SIZE = 16.0f;

    public static FontUsage Roboto => GetFont();
    public static FontUsage RobotoCondensed => GetFont(FontTypeface.RobotoCondensed);

#if (IncludeFontInter)
    public static FontUsage Inter => GetFont(FontTypeface.Inter);
#endif
#if (IncludeFontMonogram)
    public static FontUsage Monogram => GetFont(FontTypeface.Monogram);
#endif
#if (IncludeFontSMW)
    public static FontUsage SMW => GetFont(FontTypeface.SMW);
#endif

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
#if (IncludeFontInter)
    Inter,
#endif
#if (IncludeFontMonogram)
    Monogram,
#endif
#if (IncludeFontSMW)
    SMW,
#endif
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
