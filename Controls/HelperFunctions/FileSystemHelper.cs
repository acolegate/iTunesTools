using System;
using System.IO;
using System.Linq;

namespace CustomControls.HelperFunctions
{
    public static class FileSystemHelper
    {
        public static void DeleteEmptyDirs(string directory)
        {
            if (String.IsNullOrEmpty(directory))
            {
                throw new ArgumentException("Starting directory is a null reference or an empty string", "directory");
            }

            try
            {
                foreach (string childDirectory in Directory.EnumerateDirectories(directory))
                {
                    DeleteEmptyDirs(childDirectory);
                }

                if (!Directory.EnumerateFileSystemEntries(directory).Any())
                {
                    try
                    {
                        Directory.Delete(directory);
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                    catch (DirectoryNotFoundException)
                    {
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}