using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MagicAssets.Core;
using Microsoft.Xna.Framework.Graphics;

namespace SampleGame.Game.Graphics.Textures;

public class TextureServer : IAssetServer<Texture2D>
{
    public GraphicsDevice? GraphicsDevice { get; set; }

    private readonly AssetServer<byte[]> underlyingServer;

    public TextureServer(AssetServer<byte[]> underlyingServer, GraphicsDevice? graphicsDevice = null)
    {
        GraphicsDevice = graphicsDevice;
        this.underlyingServer = underlyingServer;

        underlyingServer.AddExtension("png");
        underlyingServer.AddExtension("jpg");
    }

    public Texture2D? Fetch(string uri)
    {
        using var stream = underlyingServer.FetchStream(uri);

        return stream != null
            ? Texture2D.FromStream(GraphicsDevice, stream)
            : null;
    }

    public async Task<Texture2D?> FetchAsync(string uri, CancellationToken cancellationToken = default)
    {
        await using var stream = underlyingServer.FetchStream(uri);

        return stream != null
            ? Texture2D.FromStream(GraphicsDevice, stream)
            : null;
    }

    public Stream? FetchStream(string uri)
    {
        return underlyingServer.FetchStream(uri);
    }

    public IEnumerable<string> GetAvailableAssets()
    {
        return underlyingServer.GetAvailableAssets();
    }

    public void Dispose()
    {
        underlyingServer.Dispose();
    }
}
