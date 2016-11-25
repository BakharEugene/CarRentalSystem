using CarRentalSystem.DAL.EF;
using CarRentalSystem.DAL.Repositories;
using MarkRentalSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models
{
    public class UnitOfWork : IDisposable
    {
        private CarRentalSystemContext db = new CarRentalSystemContext();

        private CarRepository carRepository;
        private MarkRepository markRepository;
        private MarkPicturesRepository markPicturesRepository;
        private CarPicturesRepository carPicturesRepository;
        private UserRepository userRepository;
        private BodyRepository bodyRepository;
        private DriveUnitRepository driveUnitRepository;
        private FuelRepository fuelRepository;
        private TransmissionRepository transmissionRepository;
        private OrderHistoryRepository orderHistoryRepository;
        private RoleRepository roleRepository;




        public RoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }
        public OrderHistoryRepository OrderHistories
        {
            get
            {
                if (orderHistoryRepository == null)
                    orderHistoryRepository = new OrderHistoryRepository(db);
                return orderHistoryRepository;
            }
        }

        public BodyRepository Bodies
        {
            get
            {
                if (bodyRepository == null)
                    bodyRepository = new BodyRepository(db);
                return bodyRepository;
            }
        }
        public DriveUnitRepository DriveUnits
        {
            get
            {
                if (driveUnitRepository == null)
                    driveUnitRepository = new DriveUnitRepository(db);
                return driveUnitRepository;
            }
        }
        public FuelRepository Fuels
        {
            get
            {
                if (fuelRepository == null)
                    fuelRepository = new FuelRepository(db);
                return fuelRepository;
            }
        }
        public TransmissionRepository Transmissions
        {
            get
            {
                if (transmissionRepository == null)
                    transmissionRepository = new TransmissionRepository(db);
                return transmissionRepository;
            }
        }


        public MarkPicturesRepository MarksPictures
        {
            get
            {
                if (markPicturesRepository == null)
                    markPicturesRepository = new MarkPicturesRepository(db);
                return markPicturesRepository;
            }
        }

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public CarPicturesRepository CarsPictures
        {
            get
            {
                if (carPicturesRepository == null)
                    carPicturesRepository = new CarPicturesRepository(db);
                return carPicturesRepository;
            }
        }
        public CarRepository Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepository(db);
                return carRepository;
            }
        }
        public MarkRepository Marks
        {
            get
            {
                if (markRepository == null)
                    markRepository = new MarkRepository(db);
                return markRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
