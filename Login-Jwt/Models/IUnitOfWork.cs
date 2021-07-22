using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Jwt.Models
{
    public interface IUnitOfWork<T> where T : class
    {
    IGenericRepository<T> Entity { get; }

    void Save();
    }
}

