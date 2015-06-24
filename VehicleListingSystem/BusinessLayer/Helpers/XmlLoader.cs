using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer.Helpers
{
    public static class XmlLoader
    {
        public static XDocument LoadXml(this string name)
        {
            var path = name.GetFilePath();
            var xDoc = XDocument.Load(path);

            return xDoc;
        }
    }
}
