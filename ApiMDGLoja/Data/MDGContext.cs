using System;
using System.Collections.Generic;
using ApiMDGLoja.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMDGLoja.Data;

public partial class MDGContext : DbContext
{
    public MDGContext()
    {
    }

    public MDGContext(DbContextOptions<MDGContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Entrega> Entregas { get; set; }

    public virtual DbSet<ItensPedido> ItensPedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LUCAS;Database=MDG;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC07E54D8065");

            entity.Property(e => e.CpfCnpj).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Telefone).HasMaxLength(20);
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Endereco__3214EC076841F42F");

            entity.Property(e => e.Bairro).HasMaxLength(50);
            entity.Property(e => e.Cep).HasMaxLength(10);
            entity.Property(e => e.Cidade).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(2);
            entity.Property(e => e.Numero).HasMaxLength(10);
            entity.Property(e => e.Rua).HasMaxLength(100);
            entity.Property(e => e.Tipo).HasMaxLength(20);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enderecos__Clien__398D8EEE");
        });

        modelBuilder.Entity<Entrega>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Entregas__3214EC0711523E7F");

            entity.Property(e => e.CodigoRastreamento).HasMaxLength(100);
            entity.Property(e => e.DataEntrega).HasColumnType("datetime");
            entity.Property(e => e.PrevisaoEntrega).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Transportadora).HasMaxLength(100);

            entity.HasOne(d => d.Pedido).WithMany(p => p.Entregas)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Entregas__Pedido__46E78A0C");
        });

        modelBuilder.Entity<ItensPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItensPed__3214EC07E3426D5E");

            entity.ToTable("ItensPedido");

            entity.Property(e => e.PrecoUnitario).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Pedido).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItensPedi__Pedid__4316F928");

            entity.HasOne(d => d.Produto).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItensPedi__Produ__440B1D61");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedidos__3214EC070BE86765");

            entity.Property(e => e.DataPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pendente");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__Cliente__403A8C7D");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produtos__3214EC0711AF8CFB");

            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.Descricao).HasMaxLength(255);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Preco).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
