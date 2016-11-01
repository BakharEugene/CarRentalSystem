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
    public class MarkPicturesRepository:IRepository<MarkPicture>
    {
         private CarRentalSystemContext _applicationDbContext;

        public MarkPicturesRepository(CarRentalSystemContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<MarkPicture> GetAll()
        {
            List<MarkPicture> Marks = _applicationDbContext.MarkPictures.ToList();
            return Marks.ToList();
        }

        public MarkPicture GetById(int? id)
        {
            return _applicationDbContext.MarkPictures.Find(id);
        }

        public void Create(MarkPicture item)
        {
            _applicationDbContext.MarkPictures.Add(item);
        }

        public void Update(MarkPicture item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.MarkPictures.Find(id) != null)
            {
                _applicationDbContext.MarkPictures.Remove(_applicationDbContext.MarkPictures.Find(id));
            }
        }
    }
}
