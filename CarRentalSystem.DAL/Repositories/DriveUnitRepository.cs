using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRentalSystem.DAL.Models.Car;

using System.Threading.Tasks;
using CarRentalSystem.DAL.EF;
using System.Data.Entity;

namespace CarRentalSystem.DAL.Repositories
{
   public  class DriveUnitRepository:IRepository<DriveUnit>
    {
        private CarRentalSystemContext _applicationDbContext;

        public DriveUnitRepository(CarRentalSystemContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<DriveUnit> GetAll()
        {
            List<DriveUnit> driveUnits = _applicationDbContext.DriveUnits.ToList();
            return driveUnits.ToList();
        }

        public DriveUnit GetById(int? id)
        {
            return _applicationDbContext.DriveUnits.Find(id);
        }

        public void Create(DriveUnit item)
        {
            _applicationDbContext.DriveUnits.Add(item);
        }

        public void Update(DriveUnit item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.DriveUnits.Find(id) != null)
            {
                _applicationDbContext.DriveUnits.Remove(_applicationDbContext.DriveUnits.Find(id));
            }
        }
    }
}
