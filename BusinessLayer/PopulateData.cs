using System.IO;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using BusinessLayer.Helpers;
using Resources;

namespace BusinessLayer
{
    public class PopulateData : IPopulateData
    {

        private readonly string noImage = ResourceSource.IMAGE_NOT_AVAILABLE_PATH;
        public IDataAccessable DataManager { get; set; }

        public PopulateData(DataAccess dataAccessInstance)
        {
            this.DataManager = dataAccessInstance;

        }

        public IEnumerable<Vehicle> GetAllVehicles(string fileName)
        {

            var xDoc = fileName.LoadXml();

            var allVehicles = this.DataManager.GetAllVehicles(xDoc);
            var vehicles = new List<Vehicle>();
            foreach (var vehicle in allVehicles)
            {
                byte[] imageArray;
                try
                {
                    imageArray = File.ReadAllBytes(vehicle.ImagePath.GetFilePath());
                }
                catch (FileNotFoundException ex)
                {
                    imageArray = File.ReadAllBytes(noImage.GetFilePath());
                }
                catch (UnauthorizedAccessException ex)
                {
                    imageArray = File.ReadAllBytes(noImage.GetFilePath());
                }
                catch (Exception ex)
                {
                    imageArray = new byte[0];
                }

                vehicle.Image = imageArray;

                vehicles.Add(vehicle);
            }
            return vehicles;
        }

        public Vehicle GetVehicleDetails(string fileName, string id)
        {
            var xDoc = fileName.LoadXml();
            var vehicle = this.DataManager.GetVehicleDetails(xDoc,id);

            return vehicle;

        }

        public IEnumerable<Vehicle> GetModels(string fileName, string manufacturer)
        {
            var xDoc = fileName.LoadXml();

            var allVehicles = this.DataManager.GetAllVehicles(xDoc, manufacturer);

            return allVehicles;
        }
    }
}
