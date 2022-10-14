using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
	public interface IGenericService<T> where T : class
	{
		
		Task<IEnumerable<T>> GetAll();
		Task<T> GetById(int id);
		Task<T> Insert(T t);
		Task<T> Update(T t);
		Task Delete(int id);
	}
}
