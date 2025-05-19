using System;
using System.Collections.Generic;

namespace ApiMDGLoja.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public decimal Preco { get; set; }

    public int Estoque { get; set; }

    public double? Peso { get; set; }

    public string? Categoria { get; set; }

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
}
