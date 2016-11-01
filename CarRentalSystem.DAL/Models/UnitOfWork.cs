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
