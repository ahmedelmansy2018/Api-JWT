using Login_Jwt.Models.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Jwt.Models.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private IGenericRepository<T> _Entity;
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public IGenericRepository<T> Entity
        {
            get
            {
                return _Entity ?? (_Entity = new GenericRepository<T>(_context));

            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
