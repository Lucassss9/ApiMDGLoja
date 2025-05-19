using System;
using System.Collections.Generic;

namespace ApiMDGLoja.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string CpfCnpj { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
