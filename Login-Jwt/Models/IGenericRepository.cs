using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Jwt.Models
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Delete(object Id);
        T GetByID(object Id);
        void Insert(T entity);
        void Update(T entity);

    }
}