using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleListingSystem.Models
{
    public class ManufacturerVM
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        public ManufacturerVM(int id, string name)
        {
            this.ManufacturerId = id;
            this.Name = name;
        }

    }
}