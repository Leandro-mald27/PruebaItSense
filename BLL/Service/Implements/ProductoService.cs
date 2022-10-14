using BLL.Contract;
using DAL.Contract;
using DAL.Entity;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Implements
{
    public class ProductoService : GenericService<Producto>, IProductoService
    {
        private IProductoRepository productoRepository;
        public ProductoService(IProductoRepository productoRepositoryy) : base(productoRepositoryy)
        {
            this.productoRepository = productoRepositoryy;
        }
    }
}
