using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class TbDetalleventum
{
    public string CodVenta { get; set; } = null!;

    public string CodProducto { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual TbProducto CodProductoNavigation { get; set; } = null!;

    public virtual TbVentum CodVentaNavigation { get; set; } = null!;
}
