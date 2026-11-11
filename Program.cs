using ResourceManagementLab.Services;

namespace ResourceManagementLab;

internal class Program
{
    private static void Main()
    {
        string dataDirectory = Path.Combine(AppContext.BaseDirectory, "Data");
        Directory.CreateDirectory(dataDirectory);
        string filePath = Path.Combine(dataDirectory, "sample.txt");

        File.WriteAllText(filePath, "Hello from C#!\nResource management example.");

        Console.WriteLine("=== RESOURCE MANAGEMENT LAB ===\n");

        // П1, Задание 2
        Console.WriteLine("1. Проверка using при исключении:");
        try
        {
            FileReaderWithUsing.ReadFileWithError(filePath);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"[OK] Перехвачена ошибка: {ex.Message}");
            Console.WriteLine("(Ресурсы при этом были корректно освобождены блоком using)\n");
        }

        // П2, Задание 7
        Console.WriteLine("2. Проверка повторного Dispose:");
        var storage = new FileStorage(filePath);
        storage.Write("Hello");
        storage.Dispose();
        storage.Dispose(); 
        storage.Dispose();
        Console.WriteLine();

        // П2, Задание 6
        Console.WriteLine("3. Проверка использования после Dispose:");
        try
        {
            storage.Read();
        }
        catch (ObjectDisposedException)
        {
            Console.WriteLine("[OK] Получен ObjectDisposedException при попытке чтения.\n");
        }

        // П2, Задание 10
        Console.WriteLine("4. Проверка IAsyncDisposable:");
        _ = TestAsyncStorageAsync(filePath);
        Console.WriteLine();

        // П1, Задание 4
        MemoryDemo.Run();
        Console.WriteLine();

        // П2, Задание 9: Таблица необходимости IDisposable
        Console.WriteLine("5. Когда нужен IDisposable (Задание 9):");
        Console.WriteLine("- Player (string, int): НЕТ (только управляемая память).");
        Console.WriteLine("- FileStorage (FileStream): ДА (владеет внешним ресурсом).");
        Console.WriteLine("- Report (List<string>): НЕТ (список управляется GC).");
        Console.WriteLine("- SocketManager (Socket): ДА (владеет сетевым дескриптором).");
        Console.WriteLine("- Класс, читающий чужой Stream: НЕ ОБЯЗАТЕЛЬНО (если не забирает владение, использовать leaveOpen: true).");

        Console.WriteLine("\nРабота программы завершена.");
    }

    private static async Task TestAsyncStorageAsync(string filePath)
    {
        await using var asyncStorage = new AsyncFileStorage(filePath);
        await asyncStorage.WriteAsync("Асинхронная запись.");
        Console.WriteLine("Асинхронная запись выполнена.");
        // DisposeAsync вызовется автоматически при выходе из метода
    }
}