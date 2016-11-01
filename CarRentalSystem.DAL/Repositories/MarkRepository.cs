using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.DAL.Models.Car;
using CarRentalSystem.DAL.EF;
using System.Data.Entity;
using CarRentalSystem.DAL.Repositories;
namespace MarkRentalSystem.DAL.Repositories
{
    public class MarkRepository : IRepository<CarRentalSystem.DAL.Models.Car.Mark>
    {
        private CarRentalSystemContext _applicationDbContext;

        public MarkRepository(CarRentalSystemContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<Mark> GetAll()
        {
            List<Mark> Marks = _applicationDbContext.Marks.ToList();
            return Marks.ToList();
        }

        public Mark GetById(int? id)
        {
            return _applicationDbContext.Marks.Find(id);
        }

        public void Create(Mark item)
        {
            _applicationDbContext.Marks.Add(item);
        }

        public void Update(Mark item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Marks.Find(id) != null)
            {
                _applicationDbContext.Marks.Remove(_applicationDbContext.Marks.Find(id));
            }
        }
    }
}
