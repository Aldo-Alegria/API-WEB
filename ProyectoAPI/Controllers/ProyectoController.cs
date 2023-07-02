using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Models;
using ProyectoVF.Services;

namespace ProyectoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectoController : Controller
    {

        private readonly IProducto _producto;

        public ProyectoController(IProducto producto)
        {

            _producto = producto;
        }

        [HttpGet("ListarProductos")]
        public IActionResult Get()
        {
            return Ok(_producto.GetProducts());
        }
        [HttpGet("ObtenerProducto/{id}")]
        public IActionResult Get(String id)
        {
            return Ok(_producto.GetProductById(id));
        }
        [HttpGet("{id}")]


        /* [HttpDelete("delate")]
          private IActionResult remove(String id)
          {
              _producto.delate(id);
              return NoContent();
          }*/

        /* [HttpPut("modificar")]
         private IActionResult editar(TbProducto obj)
         {
             _producto.update(obj);
             return CreatedAtAction(nameof(editar), obj);
         }*/

        [HttpPost("Agregar")]
        private IActionResult adicionar(TbProducto obj)
        {
            _producto.add(obj);
            return CreatedAtAction(nameof(adicionar), obj);
        }

    }
}

