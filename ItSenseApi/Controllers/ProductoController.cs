using BLL.Service;
using DAL.Context;
using DAL.Entity;
using ItSenseApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItSenseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private DbContextApi _dbContextApi;
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            this._productoService = productoService;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _productoService.GetAll();
            return Ok(productos);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoId(int id)
        {

            try
            {
                var validarProducto = await _productoService.GetAll();
                foreach (var item in validarProducto)
                {
                    if (item.idProducto == id)
                    {
                        return Ok(item);
                        
                    }

                }
                return BadRequest(Ok(new { message = "Verifique el codigo del producto!" }));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> AddProducto(Producto producto)
        {
            try
            {
                
                var validarProducto = await _productoService.GetAll();
                foreach (var item in validarProducto)
                {
                    if(item.idProducto == producto.idProducto)
                    {
                        
                        return BadRequest(Ok(new { message = "Producto ya existe!" }));
                    }
                    
                }
              
                    await _productoService.Insert(producto);
                    return Ok(new { message = "Producto Registrado Exitosamente!" });
                
                
                

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Producto producto)
        {
            try
            {

                
                var validarProducto = await _productoService.GetAll();
                foreach (var item in validarProducto)
                {
                    if (item.idProducto == producto.idProducto)
                    {
                        item.idProducto = producto.idProducto;
                        item.nombre=producto.nombre;
                        item.estado=producto.estado;
                        item.stock = producto.stock;
                        await _productoService.Update(item);
                        return Ok(new { message = "Producto modificado con exito" });

                    }

                }
                return BadRequest(new { message = "Verifique el codigo del producto" });
                



            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var validarProducto = await _productoService.GetAll();
                foreach (var item in validarProducto)
                {
                    if (item.idProducto == id)
                    {
                        await _productoService.Delete(item.idProducto);
                        return Ok(new { message = "Producto ha eliminado con exito" });

                    }

                }
                return BadRequest(new { message = "Verifique el codigo del producto" });

                
               
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
