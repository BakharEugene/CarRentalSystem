using CarRentalSystem.DAL.Models.Car;
using CarRentalSystem.DAL.Models.Information;
using CarRentalSystem.DAL.Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Car
{
    public class Car
    {
        public int Id { get; set; }
        public int Volume { get; set; }
        public int Price { get; set; }
        public int Mileage { get; set; }
        public Enums.Fuels Fuel { get; set; }
        public Enums.Transmissions Transmission { get; set; }
        public Enums.Bodies Body { get; set; }
        public Enums.DriveUnits Drive { get; set; }
        public string Description { get; set; }
        public int? IdMark { get; set; }
        public virtual Mark Mark { get; set; }
        public string Model { get; set; }
        public virtual ICollection<CarPictures> Pictures { get; set; }
    }
}
