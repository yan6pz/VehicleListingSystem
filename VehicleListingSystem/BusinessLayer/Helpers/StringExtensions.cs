using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public static class StringExtensions
    {
        public static string GetFilePath(this string name)
        {
            var path = GetContentDirectory();
            path = path.Substring(0, path.Length - 22);
            var filePath = Path.Combine(path, name);
            return filePath;
        }
        private static string GetContentDirectory()
        {

            var folderName = AppDomain.CurrentDomain.BaseDirectory;
            //var contentPath = Path.Combine(folderName);
            folderName+="problem";
            return folderName;
        }
    }
}
