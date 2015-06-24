using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BusinessLayer;
using DataAccessLayer;
using VehicleListingSystem.Models;

namespace VehicleListingSystem.Controllers
{
    public class VehicleController : Controller
    {
        private readonly string filePath   = ConfigurationManager.AppSettings["XmlFilePath"];

        public IPopulateData CRUDDataInstance { get; private set; }
        
        public VehicleController()
            : this(new PopulateData(new DataAccess()))
        {
        }

        public VehicleController(PopulateData dataManager)
        {
            CRUDDataInstance = dataManager;
            
        }
        // GET: Vehicle
        public ActionResult Index()
        {
            try
            {
                var allVehicles = this.CRUDDataInstance.GetAllVehicles(filePath);
                var vehiclesVm = allVehicles.Select(vehicle =>
                                            new VehicleVM(vehicle.Id, vehicle.Price
                                                , vehicle.Model, vehicle.Image
                                                , vehicle.Manufacturer)).ToList();
                return View(vehiclesVm);
            }
            catch(Exception message)
            {
                return View("GlobalError",message);
            }
        }

        [HttpPost]
        public ActionResult Details(string id)
        {
            var vehicle = this.CRUDDataInstance.GetVehicleDetails(filePath,id);
          
            var vehicleVm = new VehicleVM(vehicle.Id, vehicle.Price,vehicle.Currency, vehicle.Model,
                                              vehicle.Manufacturer);
            var serializer = new JavaScriptSerializer();

            serializer.MaxJsonLength = Int32.MaxValue;

           var  result = new ContentResult
            {
                Content = serializer.Serialize(vehicleVm),
                ContentType = "application/json"
            };

           return result;
        }

        [HttpPost]
        public ActionResult GetModels(string manufacturer)
        {
            try
            {
                var allVehicles = this.CRUDDataInstance.GetModels(filePath, manufacturer);
                var vehiclesVm = allVehicles.Select(vehicle => 
                                            new VehicleVM(vehicle.Model
                                                        , vehicle.Manufacturer)).ToList();

                var serializer = new JavaScriptSerializer();

                serializer.MaxJsonLength = Int32.MaxValue;

                var result = new ContentResult
                {
                    Content = serializer.Serialize(vehiclesVm),
                    ContentType = "application/json"
                };
                return result;
            }
            catch
            {
                return View();
            }
        }
    }
}
