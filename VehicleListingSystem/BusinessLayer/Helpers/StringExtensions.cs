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
            var path = System.Web.HttpContext.Current.Server.MapPath((name));
            var pattern = "VehicleListingSystem\\VehicleListingSystem\\";

            var filePath = path.Replace(pattern, "VehicleListingSystem\\");
            if (filePath.Contains("\\Vehicle\\"))
            {
                filePath = filePath.Replace("\\Vehicle\\", "\\");
            }
            return filePath;
        }
    }
}
