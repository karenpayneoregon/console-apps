namespace GetDirFileCount.Classes;

public class DirectoryHelpers
{

    /// <summary>
    /// Determines if the folder exists from <seealso cref="folderName"/>
    /// </summary>
    /// <param name="folderName">string to check</param>
    /// <returns>true if exists, false if not exists</returns>
    public static bool FolderExists(string folderName) 
        => Directory.Exists(folderName);

    /// <summary>
    /// Get folder count and file count for top level and sub folders
    /// </summary>
    /// <param name="directory">directory to get file count</param>
    /// <param name="searchOption">Top level or all folders</param>
    /// <returns>file and directory counts</returns>
    /// <remarks>
    /// An exception is thrown if insufficient permissions for file or folder
    /// </remarks>
    public static (int directoryCount, int fileCount) DirectoryFileCount(string directory, SearchOption searchOption)
    {
        Dictionary<bool, int> dictionary = new DirectoryInfo(directory)
            .EnumerateFileSystemInfos("*", searchOption)
            .GroupBy(fsi => fsi is DirectoryInfo)
            .ToDictionary(item => item.Key, s => s.Count());

        return (dictionary.ContainsKey(true) ? dictionary[true] : 0, dictionary.ContainsKey(false) ? dictionary[false] : 0);
    }

    /// <summary>
    /// Get folder count and file count for top level and sub folders
    /// </summary>
    /// <param name="directory">directory to get file count</param>
    /// <param name="searchOption">Top level or all folders</param>
    /// <returns>file and directory counts, exception</returns>
    public static (int directoryCount, int fileCount, Exception exception) DirectoryFileCountSafe(string directory, SearchOption searchOption)
    {
        try
        {
            Dictionary<bool, int> dictionary = new DirectoryInfo(directory)
                .EnumerateFileSystemInfos("*", searchOption)
                .GroupBy(fsi => fsi is DirectoryInfo)
                .ToDictionary(item => item.Key, s => s.Count());

            return (dictionary.ContainsKey(true) ? dictionary[true] : 0, dictionary.ContainsKey(false) ? dictionary[false] : 0, null)!;
        }
        catch (Exception localException)
        {
            return (-1, -1, localException);
        }
    }


}