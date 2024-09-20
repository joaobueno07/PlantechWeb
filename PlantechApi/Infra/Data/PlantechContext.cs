using System;
using System.Collections.Generic;
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public partial class PlantechContext : DbContext
{
    public PlantechContext()
    {
    }

    public PlantechContext(DbContextOptions<PlantechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Colheitum> Colheita { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Contasreceber> Contasrecebers { get; set; }

    public virtual DbSet<Culturasperdida> Culturasperdidas { get; set; }

    public virtual DbSet<Estoque> Estoques { get; set; }

    public virtual DbSet<Fornecedore> Fornecedores { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Funcionariocargo> Funcionariocargos { get; set; }

    public virtual DbSet<Funco> Funcoes { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<Movimentacao> Movimentacaos { get; set; }

    public virtual DbSet<Niveisacesso> Niveisacessos { get; set; }

    public virtual DbSet<Ordemcompra> Ordemcompras { get; set; }

    public virtual DbSet<Permisso> Permissoes { get; set; }

    public virtual DbSet<Plantio> Plantios { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Produtosvendido> Produtosvendidos { get; set; }

    public virtual DbSet<Venda> Vendas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=../Infra/Data/Plantech.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo);

            entity.ToTable("cargos");

            entity.Property(e => e.IdCargo).HasColumnName("id_cargo");
            entity.Property(e => e.Descricao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("descricao");
            entity.Property(e => e.NomeCargo).HasColumnName("nome_cargo");

            entity.HasMany(d => d.IdFuncaos).WithMany(p => p.IdCargos)
                .UsingEntity<Dictionary<string, object>>(
                    "Cargofuncao",
                    r => r.HasOne<Funco>().WithMany().HasForeignKey("IdFuncao"),
                    l => l.HasOne<Cargo>().WithMany().HasForeignKey("IdCargo"),
                    j =>
                    {
                        j.HasKey("IdCargo", "IdFuncao");
                        j.ToTable("cargofuncao");
                        j.IndexerProperty<string>("IdCargo").HasColumnName("id_cargo");
                        j.IndexerProperty<int>("IdFuncao").HasColumnName("id_funcao");
                    });
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Cnpj);

            entity.ToTable("clientes");

            entity.Property(e => e.Cnpj)
                .ValueGeneratedNever()
                .HasColumnName("cnpj");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasDefaultValueSql("NULL")
                .HasColumnName("endereco");
            entity.Property(e => e.RazaoSocial).HasColumnName("razao_social");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Telefone)
                .HasDefaultValueSql("NULL")
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Colheitum>(entity =>
        {
            entity.HasKey(e => e.IdColheita);

            entity.ToTable("colheita");

            entity.Property(e => e.IdColheita)
                .ValueGeneratedNever()
                .HasColumnName("id_colheita");
            entity.Property(e => e.Data)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("data");
            entity.Property(e => e.Descricao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("descricao");
            entity.Property(e => e.IdFuncionario)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_funcionario");
            entity.Property(e => e.IdProduto)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_produto");
            entity.Property(e => e.Quantidade)
                .HasDefaultValueSql("NULL")
                .HasColumnName("quantidade");

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Colheita).HasForeignKey(d => d.IdFuncionario);

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Colheita).HasForeignKey(d => d.IdProduto);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra);

            entity.ToTable("compras");

            entity.Property(e => e.IdCompra)
                .ValueGeneratedNever()
                .HasColumnName("id_compra");
            entity.Property(e => e.Data)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("data");
            entity.Property(e => e.Descricao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("descricao");
            entity.Property(e => e.IdFornecedor)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_fornecedor");
            entity.Property(e => e.IdFuncionario)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_funcionario");
            entity.Property(e => e.Valor)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DECIMAL(10,0)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.Compras).HasForeignKey(d => d.IdFornecedor);

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Compras).HasForeignKey(d => d.IdFuncionario);
        });

        modelBuilder.Entity<Contasreceber>(entity =>
        {
            entity.HasKey(e => e.IdContaReceber);

            entity.ToTable("contasreceber");

            entity.Property(e => e.IdContaReceber)
                .ValueGeneratedNever()
                .HasColumnName("id_conta_receber");
            entity.Property(e => e.DataVencimento)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("data_vencimento");
            entity.Property(e => e.IdCliente)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_cliente");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("NULL")
                .HasColumnName("status");
            entity.Property(e => e.Valor)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DECIMAL(10,0)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Contasrecebers).HasForeignKey(d => d.IdCliente);
        });

        modelBuilder.Entity<Culturasperdida>(entity =>
        {
            entity.HasKey(e => e.IdCulturaPerdida);

            entity.ToTable("culturasperdidas");

            entity.Property(e => e.IdCulturaPerdida)
                .ValueGeneratedNever()
                .HasColumnName("id_cultura_perdida");
            entity.Property(e => e.Data)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("data");
            entity.Property(e => e.Descricao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("descricao");
            entity.Property(e => e.IdPlantio)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_plantio");
            entity.Property(e => e.Quantidade)
                .HasDefaultValueSql("NULL")
                .HasColumnName("quantidade");

            entity.HasOne(d => d.IdPlantioNavigation).WithMany(p => p.Culturasperdida).HasForeignKey(d => d.IdPlantio);
        });

        modelBuilder.Entity<Estoque>(entity =>
        {
            entity.HasKey(e => e.IdEstoque);

            entity.ToTable("estoque");

            entity.Property(e => e.IdEstoque)
                .ValueGeneratedNever()
                .HasColumnName("id_estoque");
            entity.Property(e => e.DataEntrada)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("data_entrada");
            entity.Property(e => e.DataSaida)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("data_saida");
            entity.Property(e => e.IdInsumo)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_insumo");
            entity.Property(e => e.IdProduto)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_produto");
            entity.Property(e => e.Quantidade)
                .HasDefaultValueSql("NULL")
                .HasColumnName("quantidade");
            entity.Property(e => e.TipoItem)
                .HasDefaultValueSql("NULL")
                .HasColumnName("tipo_item");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Fornecedore>(entity =>
        {
            entity.HasKey(e => e.Cnpj);

            entity.ToTable("fornecedores");

            entity.Property(e => e.Cnpj)
                .ValueGeneratedNever()
                .HasColumnName("cnpj");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasDefaultValueSql("NULL")
                .HasColumnName("endereco");
            entity.Property(e => e.RazaoSocial).HasColumnName("razao_social");
            entity.Property(e => e.Telefone)
                .HasDefaultValueSql("NULL")
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.IdFuncionario);

            entity.ToTable("funcionarios");

            entity.HasIndex(e => e.Usuario, "IX_funcionarios_usuario").IsUnique();

            entity.Property(e => e.IdFuncionario)
                .ValueGeneratedNever()
                .HasColumnName("id_funcionario");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("DATE")
                .HasColumnName("data_nascimento");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Senha).HasColumnName("senha");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Usuario).HasColumnName("usuario");
        });

        modelBuilder.Entity<Funcionariocargo>(entity =>
        {
            entity.HasKey(e => new { e.IdFuncionario, e.IdCargo, e.IdNivelAcesso });

            entity.ToTable("funcionariocargo");

            entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");
            entity.Property(e => e.IdCargo).HasColumnName("id_cargo");
            entity.Property(e => e.IdNivelAcesso).HasColumnName("id_nivel_acesso");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Funcionariocargos).HasForeignKey(d => d.IdCargo);

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Funcionariocargos).HasForeignKey(d => d.IdFuncionario);

            entity.HasOne(d => d.IdNivelAcessoNavigation).WithMany(p => p.Funcionariocargos)
                .HasForeignKey(d => d.IdNivelAcesso)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Funco>(entity =>
        {
            entity.HasKey(e => e.IdFuncao);

            entity.ToTable("funcoes");

            entity.Property(e => e.IdFuncao)
                .ValueGeneratedNever()
                .HasColumnName("id_funcao");
            entity.Property(e => e.Descricao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("descricao");
            entity.Property(e => e.NomeFuncao).HasColumnName("nome_funcao");

            entity.HasMany(d => d.IdPermissaos).WithMany(p => p.IdFuncaos)
                .UsingEntity<Dictionary<string, object>>(
                    "Funcaopermissao",
                    r => r.HasOne<Permisso>().WithMany().HasForeignKey("IdPermissao"),
                    l => l.HasOne<Funco>().WithMany().HasForeignKey("IdFuncao"),
                    j =>
                    {
                        j.HasKey("IdFuncao", "IdPermissao");
                        j.ToTable("funcaopermissao");
                        j.IndexerProperty<int>("IdFuncao").HasColumnName("id_funcao");
                        j.IndexerProperty<int>("IdPermissao").HasColumnName("id_permissao");
                    });
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo);

            entity.ToTable("insumos");

            entity.Property(e => e.IdInsumo)
                .ValueGeneratedNever()
                .HasColumnName("id_insumo");
            entity.Property(e => e.Descricao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasDefaultValueSql("NULL")
                .HasColumnName("nome");
            entity.Property(e => e.Quantidade)
                .HasDefaultValueSql("NULL")
                .HasColumnName("quantidade");
        });

        modelBuilder.Entity<Movimentacao>(entity =>
        {
            entity.HasKey(e => e.IdMovimentacao);

            entity.ToTable("movimentacao");

            entity.Property(e => e.IdMovimentacao)
                .ValueGeneratedNever()
                .HasColumnName("id_movimentacao");
            entity.Property(e => e.Data)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("data");
            entity.Property(e => e.IdInsumo)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_insumo");
            entity.Property(e => e.IdProduto)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_produto");
            entity.Property(e => e.Quantidade)
                .HasDefaultValueSql("NULL")
                .HasColumnName("quantidade");
            entity.Property(e => e.TipoItem)
                .HasDefaultValueSql("NULL")
                .HasColumnName("tipo_item");
            entity.Property(e => e.TipoMovimentacao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("tipo_movimentacao");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.Movimentacaos).HasForeignKey(d => d.IdInsumo);

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Movimentacaos).HasForeignKey(d => d.IdProduto);
        });

        modelBuilder.Entity<Niveisacesso>(entity =>
        {
            entity.HasKey(e => e.IdNivelAcesso);

            entity.ToTable("niveisacesso");

            entity.Property(e => e.IdNivelAcesso)
                .ValueGeneratedNever()
                .HasColumnName("id_nivel_acesso");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
        });

        modelBuilder.Entity<Ordemcompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdemCompra);

            entity.ToTable("ordemcompra");

            entity.Property(e => e.IdOrdemCompra)
                .ValueGeneratedNever()
                .HasColumnName("id_ordem_compra");
            entity.Property(e => e.Data)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("data");
            entity.Property(e => e.Descricao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("descricao");
            entity.Property(e => e.IdFornecedor)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_fornecedor");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("NULL")
                .HasColumnName("status");
            entity.Property(e => e.Valor)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DECIMAL(10,0)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.Ordemcompras).HasForeignKey(d => d.IdFornecedor);
        });

        modelBuilder.Entity<Permisso>(entity =>
        {
            entity.HasKey(e => e.IdPermissao);

            entity.ToTable("permissoes");

            entity.Property(e => e.IdPermissao)
                .ValueGeneratedNever()
                .HasColumnName("id_permissao");
            entity.Property(e => e.Descricao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("descricao");
            entity.Property(e => e.NomePermissao).HasColumnName("nome_permissao");
        });

        modelBuilder.Entity<Plantio>(entity =>
        {
            entity.HasKey(e => e.IdPlantio);

            entity.ToTable("plantio");

            entity.Property(e => e.IdPlantio)
                .ValueGeneratedNever()
                .HasColumnName("id_plantio");
            entity.Property(e => e.Data)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("data");
            entity.Property(e => e.Descricao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("descricao");
            entity.Property(e => e.IdFuncionario)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_funcionario");
            entity.Property(e => e.Quantidade)
                .HasDefaultValueSql("NULL")
                .HasColumnName("quantidade");

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Plantios).HasForeignKey(d => d.IdFuncionario);
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto);

            entity.ToTable("produtos");

            entity.Property(e => e.IdProduto)
                .ValueGeneratedNever()
                .HasColumnName("id_produto");
            entity.Property(e => e.Descricao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasDefaultValueSql("NULL")
                .HasColumnName("nome");
            entity.Property(e => e.Preco)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DECIMAL(10,0)")
                .HasColumnName("preco");
        });

        modelBuilder.Entity<Produtosvendido>(entity =>
        {
            entity.HasKey(e => e.IdProdutoVendido);

            entity.ToTable("produtosvendidos");

            entity.Property(e => e.IdProdutoVendido)
                .ValueGeneratedNever()
                .HasColumnName("id_produto_vendido");
            entity.Property(e => e.DataVenda)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("data_venda");
            entity.Property(e => e.IdProduto)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_produto");
            entity.Property(e => e.IdVenda)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_venda");
            entity.Property(e => e.Quantidade)
                .HasDefaultValueSql("NULL")
                .HasColumnName("quantidade");
            entity.Property(e => e.ValorTotal)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DECIMAL(10,0)")
                .HasColumnName("valor_total");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Produtosvendidos).HasForeignKey(d => d.IdProduto);

            entity.HasOne(d => d.IdVendaNavigation).WithMany(p => p.Produtosvendidos).HasForeignKey(d => d.IdVenda);
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.IdVenda);

            entity.ToTable("vendas");

            entity.Property(e => e.IdVenda)
                .ValueGeneratedNever()
                .HasColumnName("id_venda");
            entity.Property(e => e.Data)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("data");
            entity.Property(e => e.Descricao)
                .HasDefaultValueSql("NULL")
                .HasColumnName("descricao");
            entity.Property(e => e.IdCliente)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_cliente");
            entity.Property(e => e.IdFuncionario)
                .HasDefaultValueSql("NULL")
                .HasColumnName("id_funcionario");
            entity.Property(e => e.Valor)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DECIMAL(10,0)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venda).HasForeignKey(d => d.IdCliente);

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Venda).HasForeignKey(d => d.IdFuncionario);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
