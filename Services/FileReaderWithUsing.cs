namespace ResourceManagementLab.Services;

public static class FileReaderWithUsing
{
    public static string Read(string filePath)
    {
        // задание 3
        using var stream = new FileStream(filePath, 
            FileMode.Open, 
            FileAccess.Read);
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }

    public static string ReadFileWithError(string filePath)
    {
        // задание 2
        using var stream = new FileStream(filePath, 
            FileMode.Open, 
            FileAccess.Read);
        using var reader = new StreamReader(stream);
        string content = reader.ReadToEnd();
        throw new InvalidOperationException("Искусственная ошибка после чтения файла.");
    }
}