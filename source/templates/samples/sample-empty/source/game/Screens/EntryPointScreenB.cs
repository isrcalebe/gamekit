using osu.Framework.Graphics.Sprites;
using SampleGame.Game.Graphics;

namespace SampleGame.Game.Screens;

public partial class EntryPointScreenB : SampleGameScreen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        AddInternal(new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Text = "Screen B",
            Font = SampleGameFont.Roboto.With(size: 48.0f),
        });
    }
}
