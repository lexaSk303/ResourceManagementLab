namespace ResourceManagementLab.Models;

public sealed record ResourceInfo(
    string FilePath,
    long SizeBytes,
    bool IsOpen,
    string OwnerName = "Unknown"
);