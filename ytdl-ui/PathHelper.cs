using System;
using System.IO;

namespace ytdl_ui
{
    public class PathHelper
    {
        public static bool ExistsOnPath(string fileName)
        {
            return GetFullPath(fileName) != null;
        }

        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            string values = Environment.GetEnvironmentVariable("PATH");
            foreach (string path in values.Split(Path.PathSeparator))
            {
                string fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }
    }
}