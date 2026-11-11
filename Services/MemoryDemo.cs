namespace ResourceManagementLab.Services;

public static class MemoryDemo
{
    public static void Run()
    {
        Console.WriteLine("=== MEMORY DEMO ===");

        var first = new byte[1024];
        var second = new byte[1024 * 1024];
        var third = new byte[1024 * 1024 * 5];

        // TODO
        Console.WriteLine($"first (1 KB) поколение: {GC.GetGeneration(first)}");
        Console.WriteLine($"second (1 MB) поколение: {GC.GetGeneration(second)}");
        Console.WriteLine($"third (5 MB) поколение: {GC.GetGeneration(third)}");

        // TODO
        Console.WriteLine($"Сборок Gen 0: {GC.CollectionCount(0)}");
        Console.WriteLine($"Сборок Gen 1: {GC.CollectionCount(1)}");
        Console.WriteLine($"Сборок Gen 2: {GC.CollectionCount(2)}");

        first = null;
        Console.WriteLine("Ссылка на массив потеряна.");
        Console.WriteLine($"Память в куче (прибл.): {GC.GetTotalMemory(false) / 1024} KB");

        //задание 4:
        //Размер объекта НЕ определяет его поколение. Все новые объекты 
        //помещаются в поколение 0, независимо от их размера
        //Поколение меняется только тогда, когда объект "выживает" после сборки мусор
         
    }
}