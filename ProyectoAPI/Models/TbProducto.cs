using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class TbProducto
{
    public string CodProducto { get; set; } = null!;

    public string NomProducto { get; set; } = null!;

    public decimal PreProducto { get; set; }

    public int StkProducto { get; set; }

    public string EstaProducto { get; set; } = null!;

    public string CodCategoria { get; set; } = null!;

    public string? Imagenes { get; set; }

    public virtual TbCategorium CodCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleventum> TbDetalleventa { get; set; } = new List<TbDetalleventum>();
}
