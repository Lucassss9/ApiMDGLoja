using System;
using System.Collections.Generic;

namespace ApiMDGLoja.Models;

public partial class Endereco
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public string Rua { get; set; } = null!;

    public string? Numero { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public string? Cep { get; set; }

    public string? Tipo { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
