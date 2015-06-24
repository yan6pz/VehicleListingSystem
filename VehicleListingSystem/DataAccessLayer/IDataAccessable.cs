using System.Collections.Generic;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public interface IDataAccessable
    {
        IEnumerable<Vehicle> GetAllVehicles(XDocument document);
        IEnumerable<Vehicle> GetAllVehicles(XDocument document,string manufacturer);
        IEnumerable<Vehicle> GetAllVehicles(XDocument document, decimal from,decimal to);
        Vehicle GetVehicleDetails(XDocument document, string id);
        

    }
}
