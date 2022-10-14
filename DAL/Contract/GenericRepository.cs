using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contract
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContextApi context;
        public GenericRepository(DbContextApi context)
        {
            this.context = context;
        }

        public async Task Delete(int id)
        {
            var t = await GetById(id);
            if (t == null)
            {
                throw new Exception("La Entidad no existe");
            }
            context.Set<T>().Remove(t);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id) => await context.Set<T>().FindAsync(id);

        public async Task<T> Insert(T t)
        {
            context.Set<T>().Add(t);
            await context.SaveChangesAsync();
            return t;
        }

        public async Task<T> Update(T t)
        {
            context.Entry(t).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return t;
        }
    }
}
