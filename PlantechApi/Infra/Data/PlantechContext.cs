using System;
using System.Collections.Generic;
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public partial class  PlantechContext : DbContext
{
    public  PlantechContext()
    {
    }

    public  PlantechContext(DbContextOptions< PlantechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Fornecedor> Fornecedors { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<ItemConsumo> ItemConsumos { get; set; }

    public virtual DbSet<ItemProduzido> ItemProduzidos { get; set; }

    public virtual DbSet<ItensReceitum> ItensReceita { get; set; }

    public virtual DbSet<ItensVendum> ItensVenda { get; set; }

    public virtual DbSet<MatrizFilial> MatrizFilials { get; set; }

    public virtual DbSet<OrdemCompra> OrdemCompras { get; set; }

    public virtual DbSet<PagamentosConta> PagamentosContas { get; set; }

    public virtual DbSet<Producao> Producaos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<RecebeConta> RecebeContas { get; set; }

    public virtual DbSet<RelatorioCompra> RelatorioCompras { get; set; }

    public virtual DbSet<RelatorioProducao> RelatorioProducaos { get; set; }

    public virtual DbSet<RelatorioVendum> RelatorioVenda { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlite("Data Source=E:\\Faculdade\\4Semestre\\Pim\\PlantechWeb\\PlantechApi\\Infra\\Data\\Plantech.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => new { e.PkCliente, e.FuncionariosPkFuncionario, e.FuncionariosCargosPkCargos, e.FuncionariosProducaoPkProducao });

            entity.ToTable("cliente");

            entity.HasIndex(e => e.RazaoSocial, "idx_cliente_razao_social");

            entity.Property(e => e.PkCliente).HasColumnName("pk_cliente");
            entity.Property(e => e.FuncionariosPkFuncionario).HasColumnName("funcionarios_pk_funcionario");
            entity.Property(e => e.FuncionariosCargosPkCargos).HasColumnName("funcionarios_cargos_pk_cargos");
            entity.Property(e => e.FuncionariosProducaoPkProducao).HasColumnName("funcionarios_producao_pk_producao");
            entity.Property(e => e.Contato).HasColumnName("contato");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Endereco).HasColumnName("endereco");
            entity.Property(e => e.RazaoSocial).HasColumnName("razao_social");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.PkFornecedor);

            entity.ToTable("fornecedor");

            entity.HasIndex(e => e.RazaoSocial, "idx_fornecedor_razao_social");

            entity.Property(e => e.PkFornecedor).HasColumnName("pk_fornecedor");
            entity.Property(e => e.Cidade).HasColumnName("cidade");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Endereco).HasColumnName("endereco");
            entity.Property(e => e.RazaoSocial).HasColumnName("razao_social");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => new { e.PkFuncionario, e.ProducaoPkProducao });

            entity.ToTable("funcionarios");

            entity.HasIndex(e => e.Nome, "idx_funcionarios_nome");

            entity.Property(e => e.PkFuncionario).HasColumnName("pk_funcionario");
            entity.Property(e => e.ProducaoPkProducao).HasColumnName("producao_pk_producao");
            entity.Property(e => e.Cargo).HasColumnName("cargo");
            entity.Property(e => e.DataAdm)
                .HasColumnType("DATE")
                .HasColumnName("data_adm");
            entity.Property(e => e.DataDem)
                .HasColumnType("DATE")
                .HasColumnName("data_dem");
            entity.Property(e => e.Nome).HasColumnName("nome");

            entity.HasOne(d => d.ProducaoPkProducaoNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.ProducaoPkProducao)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ItemConsumo>(entity =>
        {
            entity.HasKey(e => new { e.PkItem, e.ItensReceitaPkItens, e.ProdutosPkProdutos });

            entity.ToTable("item_consumo");

            entity.Property(e => e.PkItem).HasColumnName("pk_item");
            entity.Property(e => e.ItensReceitaPkItens).HasColumnName("itens_receita_pk_itens");
            entity.Property(e => e.ProdutosPkProdutos).HasColumnName("produtos_pk_produtos");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.ItensReceitaPkItensNavigation).WithMany(p => p.ItemConsumos)
                .HasForeignKey(d => d.ItensReceitaPkItens)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProdutosPkProdutosNavigation).WithMany(p => p.ItemConsumos)
                .HasForeignKey(d => d.ProdutosPkProdutos)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ItemProduzido>(entity =>
        {
            entity.HasKey(e => new { e.PkItem, e.ProducaoPkProducao, e.ProducaoItensReceitaPkItens, e.ProdutosPkProdutos });

            entity.ToTable("item_produzido");

            entity.Property(e => e.PkItem).HasColumnName("pk_item");
            entity.Property(e => e.ProducaoPkProducao).HasColumnName("producao_pk_producao");
            entity.Property(e => e.ProducaoItensReceitaPkItens).HasColumnName("producao_itens_receita_pk_itens");
            entity.Property(e => e.ProdutosPkProdutos).HasColumnName("produtos_pk_produtos");
            entity.Property(e => e.DataValidade)
                .HasColumnType("DATE")
                .HasColumnName("data_validade");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.ProdutosPkProdutosNavigation).WithMany(p => p.ItemProduzidos)
                .HasForeignKey(d => d.ProdutosPkProdutos)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ItensReceitum>(entity =>
        {
            entity.HasKey(e => e.PkItens);

            entity.ToTable("itens_receita");

            entity.Property(e => e.PkItens)
                .ValueGeneratedNever()
                .HasColumnName("pk_itens");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
        });

        modelBuilder.Entity<ItensVendum>(entity =>
        {
            entity.HasKey(e => new { e.PkItem, e.ProdutosPkProdutos });

            entity.ToTable("itens_venda");

            entity.Property(e => e.PkItem).HasColumnName("pk_item");
            entity.Property(e => e.ProdutosPkProdutos).HasColumnName("produtos_pk_produtos");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.ValorUnitario).HasColumnName("valor_unitario");

            entity.HasOne(d => d.ProdutosPkProdutosNavigation).WithMany(p => p.ItensVenda)
                .HasForeignKey(d => d.ProdutosPkProdutos)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<MatrizFilial>(entity =>
        {
            entity.HasKey(e => e.PkEmpresa);

            entity.ToTable("matriz_filial");

            entity.Property(e => e.PkEmpresa).HasColumnName("pk_empresa");
            entity.Property(e => e.Cidade).HasColumnName("cidade");
            entity.Property(e => e.DataIni)
                .HasColumnType("DATE")
                .HasColumnName("data_ini");
            entity.Property(e => e.Endereco).HasColumnName("endereco");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.RazaoSocial).HasColumnName("razao_social");
        });

        modelBuilder.Entity<OrdemCompra>(entity =>
        {
            entity.HasKey(e => new { e.PkCompra, e.FuncionariosPkFuncionario, e.FuncionariosCargosPkCargos, e.FornecedorPkFornecedor, e.PagamentosContasPkPagamento, e.PagamentosContasFuncionariosPkFuncionario, e.PagamentosContasFuncionariosCargosPkCargos });

            entity.ToTable("ordem_compra");

            entity.Property(e => e.PkCompra).HasColumnName("pk_compra");
            entity.Property(e => e.FuncionariosPkFuncionario).HasColumnName("funcionarios_pk_funcionario");
            entity.Property(e => e.FuncionariosCargosPkCargos).HasColumnName("funcionarios_cargos_pk_cargos");
            entity.Property(e => e.FornecedorPkFornecedor).HasColumnName("fornecedor_pk_fornecedor");
            entity.Property(e => e.PagamentosContasPkPagamento).HasColumnName("pagamentos_contas_pk_pagamento");
            entity.Property(e => e.PagamentosContasFuncionariosPkFuncionario).HasColumnName("pagamentos_contas_funcionarios_pk_funcionario");
            entity.Property(e => e.PagamentosContasFuncionariosCargosPkCargos).HasColumnName("pagamentos_contas_funcionarios_cargos_pk_cargos");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.FornecedorPkFornecedorNavigation).WithMany(p => p.OrdemCompras)
                .HasForeignKey(d => d.FornecedorPkFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PagamentosConta).WithMany(p => p.OrdemCompras)
                .HasForeignKey(d => new { d.PagamentosContasPkPagamento, d.PagamentosContasFuncionariosPkFuncionario, d.PagamentosContasFuncionariosCargosPkCargos })
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PagamentosConta>(entity =>
        {
            entity.HasKey(e => new { e.PkPagamento, e.FuncionariosPkFuncionario, e.FuncionariosCargosPkCargos });

            entity.ToTable("pagamentos_contas");

            entity.Property(e => e.PkPagamento).HasColumnName("pk_pagamento");
            entity.Property(e => e.FuncionariosPkFuncionario).HasColumnName("funcionarios_pk_funcionario");
            entity.Property(e => e.FuncionariosCargosPkCargos).HasColumnName("funcionarios_cargos_pk_cargos");
            entity.Property(e => e.DataVencimento)
                .HasColumnType("DATE")
                .HasColumnName("data_vencimento");
            entity.Property(e => e.Valor).HasColumnName("valor");
        });

        modelBuilder.Entity<Producao>(entity =>
        {
            entity.HasKey(e => e.PkProducao);

            entity.ToTable("producao");

            entity.Property(e => e.PkProducao)
                .ValueGeneratedNever()
                .HasColumnName("pk_producao");
            entity.Property(e => e.Data)
                .HasColumnType("DATE")
                .HasColumnName("data");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.PkProdutos);

            entity.ToTable("produtos");

            entity.HasIndex(e => e.Nome, "idx_produtos_nome");

            entity.Property(e => e.PkProdutos)
                .ValueGeneratedNever()
                .HasColumnName("pk_produtos");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.InsumoConsumo).HasColumnName("insumo_consumo");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.PrecoCompra).HasColumnName("preco_compra");
            entity.Property(e => e.PrecoVenda).HasColumnName("preco_venda");
            entity.Property(e => e.QuantidadeEstoque).HasColumnName("quantidade_estoque");
        });

        modelBuilder.Entity<RecebeConta>(entity =>
        {
            entity.HasKey(e => new { e.PkConta, e.ClientePkCliente, e.FuncionariosPkFuncionario, e.FuncionariosCargosPkCargos, e.FuncionariosProducaoPkProducao });

            entity.ToTable("recebe_contas");

            entity.Property(e => e.PkConta).HasColumnName("pk_conta");
            entity.Property(e => e.ClientePkCliente).HasColumnName("cliente_pk_cliente");
            entity.Property(e => e.FuncionariosPkFuncionario).HasColumnName("funcionarios_pk_funcionario");
            entity.Property(e => e.FuncionariosCargosPkCargos).HasColumnName("funcionarios_cargos_pk_cargos");
            entity.Property(e => e.FuncionariosProducaoPkProducao).HasColumnName("funcionarios_producao_pk_producao");
            entity.Property(e => e.DataVencimento)
                .HasColumnType("DATE")
                .HasColumnName("data_vencimento");
            entity.Property(e => e.Valor).HasColumnName("valor");
        });

        modelBuilder.Entity<RelatorioCompra>(entity =>
        {
            entity.HasKey(e => new { e.PkRelatorio, e.FornecedorPkFornecedor, e.FuncionariosPkFuncionario, e.FuncionariosCargosPkCargos, e.FuncionariosProducaoPkProducao });

            entity.ToTable("relatorio_compra");

            entity.Property(e => e.PkRelatorio).HasColumnName("pk_relatorio");
            entity.Property(e => e.FornecedorPkFornecedor).HasColumnName("fornecedor_pk_fornecedor");
            entity.Property(e => e.FuncionariosPkFuncionario).HasColumnName("funcionarios_pk_funcionario");
            entity.Property(e => e.FuncionariosCargosPkCargos).HasColumnName("funcionarios_cargos_pk_cargos");
            entity.Property(e => e.FuncionariosProducaoPkProducao).HasColumnName("funcionarios_producao_pk_producao");
            entity.Property(e => e.Data)
                .HasColumnType("DATE")
                .HasColumnName("data");
            entity.Property(e => e.ProdutosLista).HasColumnName("produtos_lista");
            entity.Property(e => e.QuantidadeProdutos).HasColumnName("quantidade_produtos");
            entity.Property(e => e.TotalCompras).HasColumnName("total_compras");

            entity.HasOne(d => d.FornecedorPkFornecedorNavigation).WithMany(p => p.RelatorioCompras)
                .HasForeignKey(d => d.FornecedorPkFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RelatorioProducao>(entity =>
        {
            entity.HasKey(e => new { e.PkRelatorio, e.ProducaoPkProducao });

            entity.ToTable("relatorio_producao");

            entity.Property(e => e.PkRelatorio).HasColumnName("pk_relatorio");
            entity.Property(e => e.ProducaoPkProducao).HasColumnName("producao_pk_producao");
            entity.Property(e => e.Conteudo).HasColumnName("conteudo");
            entity.Property(e => e.DataRelatorio)
                .HasColumnType("DATE")
                .HasColumnName("data_relatorio");

            entity.HasOne(d => d.ProducaoPkProducaoNavigation).WithMany(p => p.RelatorioProducaos)
                .HasForeignKey(d => d.ProducaoPkProducao)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RelatorioVendum>(entity =>
        {
            entity.HasKey(e => new { e.PkRelatorio, e.FuncionariosPkFuncionario, e.FuncionariosCargosPkCargos, e.FuncionariosProducaoPkProducao });

            entity.ToTable("relatorio_venda");

            entity.Property(e => e.PkRelatorio).HasColumnName("pk_relatorio");
            entity.Property(e => e.FuncionariosPkFuncionario).HasColumnName("funcionarios_pk_funcionario");
            entity.Property(e => e.FuncionariosCargosPkCargos).HasColumnName("funcionarios_cargos_pk_cargos");
            entity.Property(e => e.FuncionariosProducaoPkProducao).HasColumnName("funcionarios_producao_pk_producao");
            entity.Property(e => e.Data)
                .HasColumnType("DATE")
                .HasColumnName("data");
            entity.Property(e => e.ProdutosLista).HasColumnName("produtos_lista");
            entity.Property(e => e.QuantidadeProdutos).HasColumnName("quantidade_produtos");
            entity.Property(e => e.TotalVendas).HasColumnName("total_vendas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
