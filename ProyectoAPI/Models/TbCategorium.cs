using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class TbCategorium
{
    public string CodCategoria { get; set; } = null!;

    public string NomCat { get; set; } = null!;

    public virtual ICollection<TbProducto> TbProductos { get; set; } = new List<TbProducto>();
}
