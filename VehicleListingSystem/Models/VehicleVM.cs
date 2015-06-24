namespace VehicleListingSystem.Models
{
    public class VehicleVM
    {

        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        //public IEnumerable<SelectListItem> Manufacturers { get; set; }

        public VehicleVM(int id, decimal price, string model, byte[] image, string manufacturer)
        {

            this.Id = id;
            this.Model = model;
            this.Image = image;
            this.Price = price;
            this.Manufacturer = manufacturer;
        }

        public VehicleVM(int id, decimal price,string currency, string model, string manufacturer)
        {

            this.Id = id;
            this.Model = model;
            this.Price = price;
            this.Currency = currency;
            this.Manufacturer = manufacturer;
        }

        public VehicleVM(string model, string manufacturer)
        {
            // TODO: Complete member initialization
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

    }
}