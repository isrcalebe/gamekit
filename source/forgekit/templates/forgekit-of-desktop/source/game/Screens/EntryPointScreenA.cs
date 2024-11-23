using osu.Framework.Graphics.Sprites;
using SampleGame.Game.Graphics;

namespace SampleGame.Game.Screens;

public partial class EntryPointScreenA : SampleGameScreen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        AddInternal(new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Text = "Screen A",
            Font = SampleGameFont.Roboto.With(size: 48.0f),
        });
    }
}
