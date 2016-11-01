using CarRentalSystem.DAL.EF;
using CarRentalSystem.DAL.Models.Pictures;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Repositories
{
    public class CarPicturesRepository:IRepository<CarPictures>
    {
        private CarRentalSystemContext _applicationDbContext;

        public CarPicturesRepository(CarRentalSystemContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<CarPictures> GetAll()
        {
            List<CarPictures> carsPictures = _applicationDbContext.CarPictures.ToList();
            return carsPictures.ToList();
        }

        public CarPictures GetById(int? id)
        {
            return _applicationDbContext.CarPictures.Find(id);
        }

        public void Create(CarPictures item)
        {
            _applicationDbContext.CarPictures.Add(item);
        }

        public void Update(CarPictures item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.CarPictures.Find(id) != null)
            {
                _applicationDbContext.CarPictures.Remove(_applicationDbContext.CarPictures.Find(id));
            }
        }
    }
}
