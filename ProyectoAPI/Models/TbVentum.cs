using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class TbVentum
{
    public string CodVenta { get; set; } = null!;

    public string CodCliente { get; set; } = null!;

    public DateTime FecVenta { get; set; }

    public decimal TotalVenta { get; set; }

    public string EstadoVenta { get; set; } = null!;

    public virtual TbCliente CodClienteNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleventum> TbDetalleventa { get; set; } = new List<TbDetalleventum>();
}
