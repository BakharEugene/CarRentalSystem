using CarRentalSystem.DAL.Models.Car;
using CarRentalSystem.DAL.Models.Information;
using CarRentalSystem.DAL.Models.Pictures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Car
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public int Volume { get; set; }
        public int Price { get; set; }
        public int Mileage { get; set; }
        [ForeignKey("Body")]
        public int? IdBody { get; set; }
        public Body Body { get; set; }
        public string Description { get; set; }
        [ForeignKey("Mark")]
        public int? IdMark { get; set; }
        public virtual Mark Mark { get; set; }
        [ForeignKey("DriveUnit")]
        public int? IdDriveUnit { get; set; }
        public virtual DriveUnit DriveUnit { get; set; }
        [ForeignKey("Transmission")]
        public int? IdTransmission { get; set; }
        public virtual Transmission Transmission { get; set; }
        [ForeignKey("Fuel")]
        public int? IdFuel { get; set; }
        public virtual Fuel Fuel { get; set; }
        public string Model { get; set; }
        public virtual ICollection<CarPictures> Pictures { get; set; }
        [ForeignKey("Status")]
        public int? IdStatus { get; set; }
        public virtual Status Status { get; set; }
    }
}
