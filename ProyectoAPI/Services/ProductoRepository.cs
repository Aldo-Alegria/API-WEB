using ProyectoAPI.Models;
using System.Collections.Generic;

namespace ProyectoVF.Services
{
    public class ProductoRepository : IProducto
    {
        private VentaC conexion = new VentaC();

        public void add(TbProducto producto)
        {
            conexion.Add(producto);
        }

      /*  public void delate(string id)
        {
            var obj = conexion.Where(tpro => tpro.CodProducto == id).FirstOrDefault();
        }*/

        public TbProducto GetProductById(String id)
        {
            var obj = (from pro in conexion.TbProductos where pro.CodProducto == id select pro).Single();
            return obj;
        }

        public IEnumerable<TbProducto> GetProducts()
        {
            return conexion.TbProductos;
        }

        /*public void update(TbProducto p)
        {
            var obj = conexion.Where(tpro => tpro.CodProducto == p.Id).FirstOrDefault();
            obj.CodProducto = p.CodProducto;
            obj.NomProducto = p.NomProducto;
            obj.PreProducto = p.PreProducto;
            obj.StkProducto = p.StkProducto;
            obj.EstaProducto = p.EstaProducto;
          
        }*/
    }
}
