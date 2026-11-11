using System.Text;

namespace ResourceManagementLab.Services;

public sealed class AsyncFileStorage : IAsyncDisposable
{
    private readonly FileStream _stream;
    private bool _disposed;

    public AsyncFileStorage(string path)
    {
        _stream = new FileStream(
            path,
            FileMode.OpenOrCreate,
            FileAccess.ReadWrite,
            FileShare.None,
            bufferSize: 4096,
            useAsync: true);
    }

    public async Task WriteAsync(string text)
    {
        ThrowIfDisposed();
        byte[] data = Encoding.UTF8.GetBytes(text);
        await _stream.WriteAsync(data);
        await _stream.FlushAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;

        await _stream.DisposeAsync();
        _disposed = true;
        Console.WriteLine("AsyncFileStorage: ресурс асинхронно освобождён.");
    }

    private void ThrowIfDisposed() => ObjectDisposedException.ThrowIf(_disposed, this);
}