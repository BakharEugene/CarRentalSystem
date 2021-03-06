﻿using CarRentalSystem.DAL.Models;
using CarRentalSystem.DAL.Models.Car;
using CarRentalSystem.DAL.Models.Order_History;
using CarRentalSystem.DAL.Models.Pictures;
using CarRentalSystem.DAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.EF
{
    public class CarRentalSystemContext : DbContext
    {
        public CarRentalSystemContext()
            : base("CarRentalSystemContext")
        {

        }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CarPictures> CarPictures { get; set; }
        public DbSet<MarkPicture> MarkPictures { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<DriveUnit> DriveUnits { get; set; }
        public DbSet<BodyPictures> BodyPictures { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
    }

}
