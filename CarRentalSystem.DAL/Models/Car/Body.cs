﻿using CarRentalSystem.DAL.Models.Pictures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Car
{
    public class Body
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
        public virtual BodyPictures BodyPictrure { get; set; }

    }
}
