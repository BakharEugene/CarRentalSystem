using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Information
{
    public class Enums
    {
        public enum Genders { Male, Female }
        public enum Fuels { Petrol, Diesel, Gas, Electric, Hybrid}
        public enum Transmissions { Automatic, Mechanical }
        public enum Bodies { Sedan, Touring, Hatchback, Minivan, SUV, Compartment, Cabriolet, Minibus, Pickup, Van }
        public enum DriveUnits { front,back,full}
    }
}
