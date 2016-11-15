using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRentalSystem.DAL.Models.Car;

using System.Threading.Tasks;
using System.Data.Entity;
using CarRentalSystem.DAL.EF;

namespace CarRentalSystem.DAL.Repositories
{
    public class TransmissionRepository:IRepository<Transmission>
    {
        private CarRentalSystemContext _applicationDbContext;

        public TransmissionRepository(CarRentalSystemContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<Transmission> GetAll()
        {
            List<Transmission> Transmissions = _applicationDbContext.Transmissions.ToList();
            return Transmissions.ToList();
        }

        public Transmission GetById(int? id)
        {
            return _applicationDbContext.Transmissions.Find(id);
        }

        public void Create(Transmission item)
        {
            _applicationDbContext.Transmissions.Add(item);
        }

        public void Update(Transmission item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Transmissions.Find(id) != null)
            {
                _applicationDbContext.Transmissions.Remove(_applicationDbContext.Transmissions.Find(id));
            }
        }
    }
}
