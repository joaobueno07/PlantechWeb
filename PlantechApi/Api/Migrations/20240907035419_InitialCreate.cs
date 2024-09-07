using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    pk_cliente = table.Column<int>(type: "INTEGER", nullable: false),
                    funcionarios_pk_funcionario = table.Column<string>(type: "TEXT", nullable: false),
                    funcionarios_cargos_pk_cargos = table.Column<int>(type: "INTEGER", nullable: false),
                    funcionarios_producao_pk_producao = table.Column<int>(type: "INTEGER", nullable: false),
                    razao_social = table.Column<string>(type: "TEXT", nullable: false),
                    endereco = table.Column<string>(type: "TEXT", nullable: false),
                    contato = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => new { x.pk_cliente, x.funcionarios_pk_funcionario, x.funcionarios_cargos_pk_cargos, x.funcionarios_producao_pk_producao });
                });

            migrationBuilder.CreateTable(
                name: "fornecedor",
                columns: table => new
                {
                    pk_fornecedor = table.Column<string>(type: "TEXT", nullable: false),
                    razao_social = table.Column<string>(type: "TEXT", nullable: false),
                    cidade = table.Column<string>(type: "TEXT", nullable: false),
                    endereco = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedor", x => x.pk_fornecedor);
                });

            migrationBuilder.CreateTable(
                name: "itens_receita",
                columns: table => new
                {
                    pk_itens = table.Column<int>(type: "INTEGER", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itens_receita", x => x.pk_itens);
                });

            migrationBuilder.CreateTable(
                name: "matriz_filial",
                columns: table => new
                {
                    pk_empresa = table.Column<string>(type: "TEXT", nullable: false),
                    razao_social = table.Column<string>(type: "TEXT", nullable: false),
                    cidade = table.Column<string>(type: "TEXT", nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: false),
                    endereco = table.Column<string>(type: "TEXT", nullable: false),
                    numero = table.Column<int>(type: "INTEGER", nullable: true),
                    data_ini = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matriz_filial", x => x.pk_empresa);
                });

            migrationBuilder.CreateTable(
                name: "pagamentos_contas",
                columns: table => new
                {
                    pk_pagamento = table.Column<string>(type: "TEXT", nullable: false),
                    funcionarios_pk_funcionario = table.Column<string>(type: "TEXT", nullable: false),
                    funcionarios_cargos_pk_cargos = table.Column<int>(type: "INTEGER", nullable: false),
                    valor = table.Column<double>(type: "REAL", nullable: false),
                    data_vencimento = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamentos_contas", x => new { x.pk_pagamento, x.funcionarios_pk_funcionario, x.funcionarios_cargos_pk_cargos });
                });

            migrationBuilder.CreateTable(
                name: "producao",
                columns: table => new
                {
                    pk_producao = table.Column<int>(type: "INTEGER", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    data = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producao", x => x.pk_producao);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    pk_produtos = table.Column<int>(type: "INTEGER", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    preco_venda = table.Column<double>(type: "REAL", nullable: false),
                    quantidade_estoque = table.Column<int>(type: "INTEGER", nullable: false),
                    insumo_consumo = table.Column<int>(type: "INTEGER", nullable: false),
                    preco_compra = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.pk_produtos);
                });

            migrationBuilder.CreateTable(
                name: "recebe_contas",
                columns: table => new
                {
                    pk_conta = table.Column<int>(type: "INTEGER", nullable: false),
                    cliente_pk_cliente = table.Column<int>(type: "INTEGER", nullable: false),
                    funcionarios_pk_funcionario = table.Column<string>(type: "TEXT", nullable: false),
                    funcionarios_cargos_pk_cargos = table.Column<int>(type: "INTEGER", nullable: false),
                    funcionarios_producao_pk_producao = table.Column<int>(type: "INTEGER", nullable: false),
                    valor = table.Column<double>(type: "REAL", nullable: false),
                    data_vencimento = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recebe_contas", x => new { x.pk_conta, x.cliente_pk_cliente, x.funcionarios_pk_funcionario, x.funcionarios_cargos_pk_cargos, x.funcionarios_producao_pk_producao });
                });

            migrationBuilder.CreateTable(
                name: "relatorio_venda",
                columns: table => new
                {
                    pk_relatorio = table.Column<int>(type: "INTEGER", nullable: false),
                    funcionarios_pk_funcionario = table.Column<string>(type: "TEXT", nullable: false),
                    funcionarios_cargos_pk_cargos = table.Column<int>(type: "INTEGER", nullable: false),
                    funcionarios_producao_pk_producao = table.Column<int>(type: "INTEGER", nullable: false),
                    data = table.Column<DateTime>(type: "DATE", nullable: false),
                    total_vendas = table.Column<double>(type: "REAL", nullable: false),
                    produtos_lista = table.Column<string>(type: "TEXT", nullable: false),
                    quantidade_produtos = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relatorio_venda", x => new { x.pk_relatorio, x.funcionarios_pk_funcionario, x.funcionarios_cargos_pk_cargos, x.funcionarios_producao_pk_producao });
                });

            migrationBuilder.CreateTable(
                name: "relatorio_compra",
                columns: table => new
                {
                    pk_relatorio = table.Column<int>(type: "INTEGER", nullable: false),
                    fornecedor_pk_fornecedor = table.Column<string>(type: "TEXT", nullable: false),
                    funcionarios_pk_funcionario = table.Column<string>(type: "TEXT", nullable: false),
                    funcionarios_cargos_pk_cargos = table.Column<int>(type: "INTEGER", nullable: false),
                    funcionarios_producao_pk_producao = table.Column<int>(type: "INTEGER", nullable: false),
                    data = table.Column<DateTime>(type: "DATE", nullable: false),
                    total_compras = table.Column<double>(type: "REAL", nullable: false),
                    produtos_lista = table.Column<string>(type: "TEXT", nullable: false),
                    quantidade_produtos = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relatorio_compra", x => new { x.pk_relatorio, x.fornecedor_pk_fornecedor, x.funcionarios_pk_funcionario, x.funcionarios_cargos_pk_cargos, x.funcionarios_producao_pk_producao });
                    table.ForeignKey(
                        name: "FK_relatorio_compra_fornecedor_fornecedor_pk_fornecedor",
                        column: x => x.fornecedor_pk_fornecedor,
                        principalTable: "fornecedor",
                        principalColumn: "pk_fornecedor");
                });

            migrationBuilder.CreateTable(
                name: "ordem_compra",
                columns: table => new
                {
                    pk_compra = table.Column<int>(type: "INTEGER", nullable: false),
                    funcionarios_pk_funcionario = table.Column<string>(type: "TEXT", nullable: false),
                    funcionarios_cargos_pk_cargos = table.Column<int>(type: "INTEGER", nullable: false),
                    fornecedor_pk_fornecedor = table.Column<string>(type: "TEXT", nullable: false),
                    pagamentos_contas_pk_pagamento = table.Column<string>(type: "TEXT", nullable: false),
                    pagamentos_contas_funcionarios_pk_funcionario = table.Column<string>(type: "TEXT", nullable: false),
                    pagamentos_contas_funcionarios_cargos_pk_cargos = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordem_compra", x => new { x.pk_compra, x.funcionarios_pk_funcionario, x.funcionarios_cargos_pk_cargos, x.fornecedor_pk_fornecedor, x.pagamentos_contas_pk_pagamento, x.pagamentos_contas_funcionarios_pk_funcionario, x.pagamentos_contas_funcionarios_cargos_pk_cargos });
                    table.ForeignKey(
                        name: "FK_ordem_compra_fornecedor_fornecedor_pk_fornecedor",
                        column: x => x.fornecedor_pk_fornecedor,
                        principalTable: "fornecedor",
                        principalColumn: "pk_fornecedor");
                    table.ForeignKey(
                        name: "FK_ordem_compra_pagamentos_contas_pagamentos_contas_pk_pagamento_pagamentos_contas_funcionarios_pk_funcionario_pagamentos_contas_funcionarios_cargos_pk_cargos",
                        columns: x => new { x.pagamentos_contas_pk_pagamento, x.pagamentos_contas_funcionarios_pk_funcionario, x.pagamentos_contas_funcionarios_cargos_pk_cargos },
                        principalTable: "pagamentos_contas",
                        principalColumns: new[] { "pk_pagamento", "funcionarios_pk_funcionario", "funcionarios_cargos_pk_cargos" });
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    pk_funcionario = table.Column<string>(type: "TEXT", nullable: false),
                    producao_pk_producao = table.Column<int>(type: "INTEGER", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    cargo = table.Column<string>(type: "TEXT", nullable: false),
                    data_adm = table.Column<DateTime>(type: "DATE", nullable: false),
                    data_dem = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => new { x.pk_funcionario, x.producao_pk_producao });
                    table.ForeignKey(
                        name: "FK_funcionarios_producao_producao_pk_producao",
                        column: x => x.producao_pk_producao,
                        principalTable: "producao",
                        principalColumn: "pk_producao");
                });

            migrationBuilder.CreateTable(
                name: "relatorio_producao",
                columns: table => new
                {
                    pk_relatorio = table.Column<int>(type: "INTEGER", nullable: false),
                    producao_pk_producao = table.Column<int>(type: "INTEGER", nullable: false),
                    data_relatorio = table.Column<DateTime>(type: "DATE", nullable: false),
                    conteudo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relatorio_producao", x => new { x.pk_relatorio, x.producao_pk_producao });
                    table.ForeignKey(
                        name: "FK_relatorio_producao_producao_producao_pk_producao",
                        column: x => x.producao_pk_producao,
                        principalTable: "producao",
                        principalColumn: "pk_producao");
                });

            migrationBuilder.CreateTable(
                name: "item_consumo",
                columns: table => new
                {
                    pk_item = table.Column<int>(type: "INTEGER", nullable: false),
                    itens_receita_pk_itens = table.Column<int>(type: "INTEGER", nullable: false),
                    produtos_pk_produtos = table.Column<int>(type: "INTEGER", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    valor = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_consumo", x => new { x.pk_item, x.itens_receita_pk_itens, x.produtos_pk_produtos });
                    table.ForeignKey(
                        name: "FK_item_consumo_itens_receita_itens_receita_pk_itens",
                        column: x => x.itens_receita_pk_itens,
                        principalTable: "itens_receita",
                        principalColumn: "pk_itens");
                    table.ForeignKey(
                        name: "FK_item_consumo_produtos_produtos_pk_produtos",
                        column: x => x.produtos_pk_produtos,
                        principalTable: "produtos",
                        principalColumn: "pk_produtos");
                });

            migrationBuilder.CreateTable(
                name: "item_produzido",
                columns: table => new
                {
                    pk_item = table.Column<int>(type: "INTEGER", nullable: false),
                    producao_pk_producao = table.Column<int>(type: "INTEGER", nullable: false),
                    producao_itens_receita_pk_itens = table.Column<int>(type: "INTEGER", nullable: false),
                    produtos_pk_produtos = table.Column<int>(type: "INTEGER", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    valor = table.Column<double>(type: "REAL", nullable: false),
                    data_validade = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_produzido", x => new { x.pk_item, x.producao_pk_producao, x.producao_itens_receita_pk_itens, x.produtos_pk_produtos });
                    table.ForeignKey(
                        name: "FK_item_produzido_produtos_produtos_pk_produtos",
                        column: x => x.produtos_pk_produtos,
                        principalTable: "produtos",
                        principalColumn: "pk_produtos");
                });

            migrationBuilder.CreateTable(
                name: "itens_venda",
                columns: table => new
                {
                    pk_item = table.Column<int>(type: "INTEGER", nullable: false),
                    produtos_pk_produtos = table.Column<int>(type: "INTEGER", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    valor_unitario = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itens_venda", x => new { x.pk_item, x.produtos_pk_produtos });
                    table.ForeignKey(
                        name: "FK_itens_venda_produtos_produtos_pk_produtos",
                        column: x => x.produtos_pk_produtos,
                        principalTable: "produtos",
                        principalColumn: "pk_produtos");
                });

            migrationBuilder.CreateIndex(
                name: "idx_cliente_razao_social",
                table: "cliente",
                column: "razao_social");

            migrationBuilder.CreateIndex(
                name: "idx_fornecedor_razao_social",
                table: "fornecedor",
                column: "razao_social");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_producao_pk_producao",
                table: "funcionarios",
                column: "producao_pk_producao");

            migrationBuilder.CreateIndex(
                name: "idx_funcionarios_nome",
                table: "funcionarios",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "IX_item_consumo_itens_receita_pk_itens",
                table: "item_consumo",
                column: "itens_receita_pk_itens");

            migrationBuilder.CreateIndex(
                name: "IX_item_consumo_produtos_pk_produtos",
                table: "item_consumo",
                column: "produtos_pk_produtos");

            migrationBuilder.CreateIndex(
                name: "IX_item_produzido_produtos_pk_produtos",
                table: "item_produzido",
                column: "produtos_pk_produtos");

            migrationBuilder.CreateIndex(
                name: "IX_itens_venda_produtos_pk_produtos",
                table: "itens_venda",
                column: "produtos_pk_produtos");

            migrationBuilder.CreateIndex(
                name: "IX_ordem_compra_fornecedor_pk_fornecedor",
                table: "ordem_compra",
                column: "fornecedor_pk_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_ordem_compra_pagamentos_contas_pk_pagamento_pagamentos_contas_funcionarios_pk_funcionario_pagamentos_contas_funcionarios_cargos_pk_cargos",
                table: "ordem_compra",
                columns: new[] { "pagamentos_contas_pk_pagamento", "pagamentos_contas_funcionarios_pk_funcionario", "pagamentos_contas_funcionarios_cargos_pk_cargos" });

            migrationBuilder.CreateIndex(
                name: "idx_produtos_nome",
                table: "produtos",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "IX_relatorio_compra_fornecedor_pk_fornecedor",
                table: "relatorio_compra",
                column: "fornecedor_pk_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_relatorio_producao_producao_pk_producao",
                table: "relatorio_producao",
                column: "producao_pk_producao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "item_consumo");

            migrationBuilder.DropTable(
                name: "item_produzido");

            migrationBuilder.DropTable(
                name: "itens_venda");

            migrationBuilder.DropTable(
                name: "matriz_filial");

            migrationBuilder.DropTable(
                name: "ordem_compra");

            migrationBuilder.DropTable(
                name: "recebe_contas");

            migrationBuilder.DropTable(
                name: "relatorio_compra");

            migrationBuilder.DropTable(
                name: "relatorio_producao");

            migrationBuilder.DropTable(
                name: "relatorio_venda");

            migrationBuilder.DropTable(
                name: "itens_receita");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "pagamentos_contas");

            migrationBuilder.DropTable(
                name: "fornecedor");

            migrationBuilder.DropTable(
                name: "producao");
        }
    }
}
