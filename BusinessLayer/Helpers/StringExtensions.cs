using System;

namespace BusinessLayer.Helpers
{
    public static class StringExtensions
    {
        public static string GetFilePath(this string name)
        {
            var path = GetContentDirectory();
            path = path.Substring(0, path.Length - 22);
            var filePath = System.IO.Path.Combine(path, name);
            return filePath;
        }
        private static string GetContentDirectory()
        {
            var folderName = AppDomain.CurrentDomain.BaseDirectory;

            return folderName;
        }
    }
}
