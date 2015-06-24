using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.Helpers
{
   public static class XmlHelpers
    {
       public static string ElementByNameAttribute(this XElement container,string attribute,
                                              string name="")
       {

           return container.Attribute(attribute) != null ? container.Attribute(attribute).Value : string.Empty; //(x => x.Attribute(attribute).Value == name);
       }
    }
}
