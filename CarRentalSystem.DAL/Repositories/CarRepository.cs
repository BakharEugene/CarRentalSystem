using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.DAL.Models.Car;
using CarRentalSystem.DAL.EF;
using System.Data.Entity;
namespace CarRentalSystem.DAL.Repositories
{
    public class CarRepository : IRepository<CarRentalSystem.DAL.Models.Car.Car>
    {
        private CarRentalSystemContext _applicationDbContext;

        public CarRepository(CarRentalSystemContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<Car> GetAll()
        {
            List<Car> cars = _applicationDbContext.Cars.ToList();
            return cars.ToList();
        }

        public Car GetById(int? id)
        {
            return _applicationDbContext.Cars.Find(id);
        }

        public void Create(Car item)
        {
            _applicationDbContext.Cars.Add(item);
        }

        public void Update(Car item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Cars.Find(id) != null)
            {
                _applicationDbContext.Cars.Remove(_applicationDbContext.Cars.Find(id));
            }
        }
    }
}
