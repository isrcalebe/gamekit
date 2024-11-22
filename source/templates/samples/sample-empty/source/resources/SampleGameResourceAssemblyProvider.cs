using System.Reflection;

namespace SampleGame.Game.Resources;

public static class SampleGameResourceAssemblyProvider
{
    public static Assembly Assembly => typeof(SampleGameResourceAssemblyProvider).Assembly;
}
