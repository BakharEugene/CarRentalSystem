using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Repositories
{
    interface IRepository<T>
    where T : class
    {
        IEnumerable<T> GetAll(); // получение всех объектов
        T GetById(int? id); // получение одного объекта  по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
