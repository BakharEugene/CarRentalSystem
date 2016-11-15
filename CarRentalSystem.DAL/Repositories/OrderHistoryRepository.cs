using CarRentalSystem.DAL.EF;
using CarRentalSystem.DAL.Models.Order_History;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Repositories
{
    public class OrderHistoryRepository:IRepository<OrderHistory>
    {
         private CarRentalSystemContext _applicationDbContext;

        public OrderHistoryRepository(CarRentalSystemContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<OrderHistory> GetAll()
        {
            List<OrderHistory> OrderHistories = _applicationDbContext.OrderHistories.ToList();
            return OrderHistories.ToList();
        }

        public OrderHistory GetById(int? id)
        {
            return _applicationDbContext.OrderHistories.Find(id);
        }

        public void Create(OrderHistory item)
        {
            _applicationDbContext.OrderHistories.Add(item);
        }

        public void Update(OrderHistory item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.OrderHistories.Find(id) != null)
            {
                _applicationDbContext.OrderHistories.Remove(_applicationDbContext.OrderHistories.Find(id));
            }
        }
    }
}
