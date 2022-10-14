using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        /*Devolver todos*/
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T t);
        Task<T> Update(T t);
        Task Delete(int id);
    }
}
