using System.Collections.Generic;
using osu.Framework.Configuration;
using osu.Framework.Platform;
using SampleGame.Game.Configuration.Settings;

namespace SampleGame.Game.Configuration;

public class SampleGameConfigManager : IniConfigManager<SampleGameSetting>
{
    protected override string Filename => "SPC_KB_ProjectName.ini";

    public SampleGameConfigManager(Storage storage, IDictionary<SampleGameSetting, object>? defaultOverrides = null)
        : base(storage, defaultOverrides)
    {
        PerformSave();
    }

    protected override void InitialiseDefaults()
    {
        SetDefault(SampleGameSetting.ScreenEntryPoint, ScreenEntryPoint.ScreenA);
    }
}
