using CarRentalSystem.DAL.EF;
using CarRentalSystem.DAL.Models.Car;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Repositories
{
    public class BodyRepository:IRepository<Body>
    {
         private CarRentalSystemContext _applicationDbContext;

        public BodyRepository(CarRentalSystemContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<Body> GetAll()
        {
            List<Body> bodies = _applicationDbContext.Bodies.ToList();
            return bodies.ToList();
        }

        public Body GetById(int? id)
        {
            return _applicationDbContext.Bodies.Find(id);
        }

        public void Create(Body item)
        {
            _applicationDbContext.Bodies.Add(item);
        }

        public void Update(Body item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Bodies.Find(id) != null)
            {
                _applicationDbContext.Bodies.Remove(_applicationDbContext.Bodies.Find(id));
            }
        }
    }
}
