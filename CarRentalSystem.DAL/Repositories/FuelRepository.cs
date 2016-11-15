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
    public class FuelRepository:IRepository<Fuel>
    {
        private CarRentalSystemContext _applicationDbContext;

        public FuelRepository(CarRentalSystemContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<Fuel> GetAll()
        {
            List<Fuel> Fuels = _applicationDbContext.Fuels.ToList();
            return Fuels.ToList();
        }

        public Fuel GetById(int? id)
        {
            return _applicationDbContext.Fuels.Find(id);
        }

        public void Create(Fuel item)
        {
            _applicationDbContext.Fuels.Add(item);
        }

        public void Update(Fuel item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Fuels.Find(id) != null)
            {
                _applicationDbContext.Fuels.Remove(_applicationDbContext.Fuels.Find(id));
            }
        }
    }
}
