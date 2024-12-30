using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using MagicAssets.Core;
using MagicAssets.Providers.AssemblyAssetServer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleGame.Game.Graphics.Textures;
using SampleGame.Game.Logging;
using SampleGame.Game.Resources;

namespace SampleGame.Game;

public abstract class SampleGameGameBase : Microsoft.Xna.Framework.Game
{
    protected GraphicsDeviceManager GraphicsDeviceManager { get; }

    protected SpriteBatch? SpriteBatch { get; private set; }

    protected AssetServer<byte[]> Assets { get; }

    protected TextureServer Textures { get; }

    protected SampleGameGameBase()
    {
        Logger.Setup();

        GraphicsDeviceManager = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 1366,
            PreferredBackBufferHeight = 768
        };
        Assets = new AssetServer<byte[]>();
        Textures = new TextureServer(Assets);

        Window.Title = "SampleGame";
    }

    protected override void Initialize()
    {
        AppDomain.CurrentDomain.UnhandledException += unhandledExceptionHandler;
        TaskScheduler.UnobservedTaskException += unobservedExceptionHandler!;

        Assets.AddServer(new AssemblyAssetServer(SampleGameResourceAssemblyProvider.Assembly));
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        Textures.GraphicsDevice = GraphicsDevice;

        foreach (var asset in Textures.GetAvailableAssets())
            Logger.Information.Debug("Loaded texture: {0}", asset);

        base.Initialize();
    }

    #region Exception Handling

    public event Func<Exception, bool>? ExceptionThrown;

    private void unhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        var exception = (Exception)e.ExceptionObject;

        Logger.Runtime.Fatal(exception, "An unhandled error has occurred.");
        abortExecutionFromException(sender, exception, e.IsTerminating);
    }

    private void unobservedExceptionHandler(object sender, UnobservedTaskExceptionEventArgs e)
    {
        var exception = e.Exception;

        Logger.Runtime.Fatal(exception, "An unobserved error has occurred.");
        abortExecutionFromException(sender, exception, false);
    }

    private void abortExecutionFromException(object sender, Exception exception, bool isTerminating)
    {
        if (ExceptionThrown?.Invoke(exception) == true)
            return;

        AppDomain.CurrentDomain.UnhandledException -= unhandledExceptionHandler;
        TaskScheduler.UnobservedTaskException -= unobservedExceptionHandler!;

        var captured = ExceptionDispatchInfo.Capture(exception);
        var thrownEvent = new ManualResetEventSlim(false);

        try
        {
            captured.Throw();
        }
        finally
        {
            thrownEvent.Set();
        }

        waitForThrow();

        void waitForThrow()
        {
            if (isTerminating)
                return;

            thrownEvent.Wait(TimeSpan.FromSeconds(10));
        }
    }

    #endregion
}
