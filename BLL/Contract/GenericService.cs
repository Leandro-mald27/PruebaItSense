using BLL.Service;
using DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private IGenericRepository<T> _genericRepository;
        public GenericService(IGenericRepository<T> genericRepository)
        {
            this._genericRepository = genericRepository;
        }

        public async Task Delete(int id)
        {
            await _genericRepository.Delete(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _genericRepository.GetAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _genericRepository.GetById(id);
        }

        public async Task<T> Insert(T t)
        {
            return await _genericRepository.Insert(t);
        }

        public async Task<T> Update(T t)
        {
            return await _genericRepository.Update(t);
        }
    }
}
