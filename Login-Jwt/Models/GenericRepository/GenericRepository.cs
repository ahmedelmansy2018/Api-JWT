using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Jwt.Models.GenericRepository
{
  public  class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public DbSet<T> Table = null;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            Table = _context.Set<T>();

        }
        public void Delete(object Id)
        {
            T Existing = GetByID(Id);
            Table.Remove(Existing);
        }

        public IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetByID(object Id)
        {
            return Table.Find(Id);
        }

        public void Insert(T entity)
        {
            Table.Add(entity);
        }

        public void Update(T entity)
        {
            Table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
