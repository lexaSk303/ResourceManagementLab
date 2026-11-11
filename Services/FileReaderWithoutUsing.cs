namespace ResourceManagementLab.Services;

public static class FileReaderWithoutUsing
{
    public static string Read(string filePath)
    {
        // задание 1
        var stream = new FileStream(filePath, 
            FileMode.Open, 
            FileAccess.Read);
        var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
}
