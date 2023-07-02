using ProyectoAPI.Models;

namespace ProyectoVF.Services
{
    public interface IProducto
    {
        IEnumerable<TbProducto> GetProducts();
        TbProducto GetProductById(String id);
        void add(TbProducto producto);
        /*void update(TbProducto producto);
        void delate(String id);*/
    }
}
