using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Pictures
{
    public class CarPictures
    {
        
        public int Id { get; set; }
        public string Path { get; set; }
        public CarPictures(string path, Car.Car car)
        {
            this.Path = path;
            this.Car = car;
        }
        public int? CarId { get; set; }
        public virtual Car.Car Car { get; set; }
        public CarPictures()
        { }
    }
}
