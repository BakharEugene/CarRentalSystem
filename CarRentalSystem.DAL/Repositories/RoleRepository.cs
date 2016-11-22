using CarRentalSystem.DAL.EF;
using CarRentalSystem.DAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Repositories
{
    public class RoleRepository : IRepository<Role>
    {

        private CarRentalSystemContext _applicationDbContext;

        public RoleRepository(CarRentalSystemContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<Role> GetAll()
        {
            List<Role> Roles = _applicationDbContext.Roles.ToList();
            return Roles.ToList();
        }

        public Role GetById(int? id)
        {
            return _applicationDbContext.Roles.Find(id);
        }

        public void Create(Role item)
        {
            _applicationDbContext.Roles.Add(item);
        }

        public void Update(Role item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Roles.Find(id) != null)
            {
                _applicationDbContext.Roles.Remove(_applicationDbContext.Roles.Find(id));
            }
        }
    }
}
