using System;
using System.Collections.Generic;

namespace ApiMDGLoja.Models;

public partial class Entrega
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public string? Transportadora { get; set; }

    public DateTime? PrevisaoEntrega { get; set; }

    public DateTime? DataEntrega { get; set; }

    public string? Status { get; set; }

    public string? CodigoRastreamento { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;
}
