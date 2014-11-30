using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IPopulateData
    {
        IEnumerable<Vehicle> GetAllVehicles(string fileName);
        Vehicle GetVehicleDetails(string fileName, string id);
        IEnumerable<Vehicle> GetModels(string fileName,string manufacturer);
        //IEnumerable<Vehicle> GetVehiclesFilter(string fileName, string model, string manufacturer, decimal price);
    }
}
