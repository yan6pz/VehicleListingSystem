using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataAccessLayer.Helpers;

namespace DataAccessLayer
{
    public class DataAccess : IDataAccessable
    {

        public IEnumerable<Vehicle> GetAllVehicles(XDocument document)
        {
            var vehicles = new List<Vehicle>();

            if (document.Root == null)
                return vehicles;

            foreach (var vehicle in document.Descendants("Vehicle"))
            {
                var vehicleData = new Vehicle
                    {
                        Id = int.Parse(vehicle.ElementByNameAttribute( "id")),
                        Model = vehicle.ElementByNameAttribute( "model"),
                        ImagePath = vehicle.ElementByNameAttribute( "image"),
                        Price = decimal.Parse(vehicle.ElementByNameAttribute("price")),
                        Manufacturer = vehicle.ElementByNameAttribute("manufacturer")
                    };
                
                vehicles.Add(vehicleData);
            }
            

            return vehicles;
        }

        public IEnumerable<Vehicle> GetAllVehicles(XDocument document, string manufacturer)
        {
            var vehicles = new List<Vehicle>();

            if (document.Root == null)
                return vehicles;

            var xmlVehicles = (from el in document.Root.Elements("Vehicle")
                              where (string)el.Attribute("manufacturer") == manufacturer
                              select el);

            foreach (var vehicle in xmlVehicles)
            {
                var vehicleData = new Vehicle
                {
                    Model = vehicle.ElementByNameAttribute("model"),
                    Manufacturer = vehicle.ElementByNameAttribute("manufacturer")
                };

                vehicles.Add(vehicleData);
            }
            return vehicles;

        }

        public Vehicle GetVehicleDetails(XDocument document, string id)
        {
            var vehicle = new Vehicle();

            if (document.Root == null)
                return vehicle;

            var xmlVehicle = (from el in document.Root.Elements("Vehicle")
                             where (string)el.Attribute("id") == id
                             select el).First(); 
           
                var vehicleData = new Vehicle
                {
                    Id = int.Parse(xmlVehicle.ElementByNameAttribute("id")),
                    Model = xmlVehicle.ElementByNameAttribute("model"),
                    Price = decimal.Parse(xmlVehicle.ElementByNameAttribute("price")),
                    Currency = xmlVehicle.ElementByNameAttribute("currency"),
                    Manufacturer = xmlVehicle.ElementByNameAttribute("manufacturer")
                };

                return vehicleData;
        }
        public IEnumerable<Vehicle> GetAllVehicles(XDocument document, decimal from, decimal to)
        {
            throw new NotImplementedException();
        }


    }
}
