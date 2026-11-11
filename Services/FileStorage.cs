using System.Text;

namespace ResourceManagementLab.Services;

public sealed class FileStorage : IDisposable
{
    private readonly FileStream _stream;
    private bool _disposed;

    // TODO 1
    public FileStorage(string filePath)
    {
        _stream = new FileStream(
            filePath,
            FileMode.OpenOrCreate
            FileAccess.ReadWrite,
            FileShare.None);
    }

    public void Write(string text)
    {
        // TODO 2
        ThrowIfDisposed();

        // TODO 3 и 4
        byte[] data = Encoding.UTF8.GetBytes(text);
        _stream.Write(data);
        _stream.Flush();
    }

    public string Read()
    {
        // TODO 5
        // TODO 6
        // TODO 7 и 8
        ThrowIfDisposed();
        _stream.Position = 0;
        using var reader = new StreamReader(
            _stream,
            Encoding.UTF8,
            detectEncodingFromByteOrderMarks: true,
            bufferSize: 1024,
            leaveOpen: true);

        return reader.ReadToEnd();
    }

    public void Dispose()
    {
        // TODO 8
        // TODO 9
        // TODO 10
        if (_disposed)
        {
            return;
        }

        _stream.Dispose();
        _disposed = true;
        Console.WriteLine("FileStorage: ресурс освобождён.");
    }

    // Задание 6
    private void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }
}