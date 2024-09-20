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
                name: "cargos",
                columns: table => new
                {
                    id_cargo = table.Column<string>(type: "TEXT", nullable: false),
                    nome_cargo = table.Column<string>(type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargos", x => x.id_cargo);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    cnpj = table.Column<int>(type: "INTEGER", nullable: false),
                    razao_social = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    telefone = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    endereco = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.cnpj);
                });

            migrationBuilder.CreateTable(
                name: "fornecedores",
                columns: table => new
                {
                    cnpj = table.Column<int>(type: "INTEGER", nullable: false),
                    razao_social = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    telefone = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    endereco = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedores", x => x.cnpj);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    id_funcionario = table.Column<int>(type: "INTEGER", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    usuario = table.Column<string>(type: "TEXT", nullable: false),
                    senha = table.Column<string>(type: "TEXT", nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "DATE", nullable: true),
                    status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.id_funcionario);
                });

            migrationBuilder.CreateTable(
                name: "funcoes",
                columns: table => new
                {
                    id_funcao = table.Column<int>(type: "INTEGER", nullable: false),
                    nome_funcao = table.Column<string>(type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcoes", x => x.id_funcao);
                });

            migrationBuilder.CreateTable(
                name: "insumos",
                columns: table => new
                {
                    id_insumo = table.Column<int>(type: "INTEGER", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    descricao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insumos", x => x.id_insumo);
                });

            migrationBuilder.CreateTable(
                name: "niveisacesso",
                columns: table => new
                {
                    id_nivel_acesso = table.Column<int>(type: "INTEGER", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_niveisacesso", x => x.id_nivel_acesso);
                });

            migrationBuilder.CreateTable(
                name: "permissoes",
                columns: table => new
                {
                    id_permissao = table.Column<int>(type: "INTEGER", nullable: false),
                    nome_permissao = table.Column<string>(type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissoes", x => x.id_permissao);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id_produto = table.Column<int>(type: "INTEGER", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    descricao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    preco = table.Column<decimal>(type: "DECIMAL(10,0)", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.id_produto);
                });

            migrationBuilder.CreateTable(
                name: "contasreceber",
                columns: table => new
                {
                    id_conta_receber = table.Column<int>(type: "INTEGER", nullable: false),
                    id_cliente = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    valor = table.Column<decimal>(type: "DECIMAL(10,0)", nullable: true, defaultValueSql: "NULL"),
                    data_vencimento = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "NULL"),
                    status = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contasreceber", x => x.id_conta_receber);
                    table.ForeignKey(
                        name: "FK_contasreceber_clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "cnpj");
                });

            migrationBuilder.CreateTable(
                name: "ordemcompra",
                columns: table => new
                {
                    id_ordem_compra = table.Column<int>(type: "INTEGER", nullable: false),
                    id_fornecedor = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    data = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "NULL"),
                    descricao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    valor = table.Column<decimal>(type: "DECIMAL(10,0)", nullable: true, defaultValueSql: "NULL"),
                    status = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordemcompra", x => x.id_ordem_compra);
                    table.ForeignKey(
                        name: "FK_ordemcompra_fornecedores_id_fornecedor",
                        column: x => x.id_fornecedor,
                        principalTable: "fornecedores",
                        principalColumn: "cnpj");
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    id_compra = table.Column<int>(type: "INTEGER", nullable: false),
                    id_fornecedor = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    data = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "NULL"),
                    descricao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    id_funcionario = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    valor = table.Column<decimal>(type: "DECIMAL(10,0)", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.id_compra);
                    table.ForeignKey(
                        name: "FK_compras_fornecedores_id_fornecedor",
                        column: x => x.id_fornecedor,
                        principalTable: "fornecedores",
                        principalColumn: "cnpj");
                    table.ForeignKey(
                        name: "FK_compras_funcionarios_id_funcionario",
                        column: x => x.id_funcionario,
                        principalTable: "funcionarios",
                        principalColumn: "id_funcionario");
                });

            migrationBuilder.CreateTable(
                name: "plantio",
                columns: table => new
                {
                    id_plantio = table.Column<int>(type: "INTEGER", nullable: false),
                    id_funcionario = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    data = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "NULL"),
                    descricao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plantio", x => x.id_plantio);
                    table.ForeignKey(
                        name: "FK_plantio_funcionarios_id_funcionario",
                        column: x => x.id_funcionario,
                        principalTable: "funcionarios",
                        principalColumn: "id_funcionario");
                });

            migrationBuilder.CreateTable(
                name: "vendas",
                columns: table => new
                {
                    id_venda = table.Column<int>(type: "INTEGER", nullable: false),
                    id_cliente = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    data = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "NULL"),
                    descricao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    id_funcionario = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    valor = table.Column<decimal>(type: "DECIMAL(10,0)", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendas", x => x.id_venda);
                    table.ForeignKey(
                        name: "FK_vendas_clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "cnpj");
                    table.ForeignKey(
                        name: "FK_vendas_funcionarios_id_funcionario",
                        column: x => x.id_funcionario,
                        principalTable: "funcionarios",
                        principalColumn: "id_funcionario");
                });

            migrationBuilder.CreateTable(
                name: "cargofuncao",
                columns: table => new
                {
                    id_cargo = table.Column<string>(type: "TEXT", nullable: false),
                    id_funcao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargofuncao", x => new { x.id_cargo, x.id_funcao });
                    table.ForeignKey(
                        name: "FK_cargofuncao_cargos_id_cargo",
                        column: x => x.id_cargo,
                        principalTable: "cargos",
                        principalColumn: "id_cargo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cargofuncao_funcoes_id_funcao",
                        column: x => x.id_funcao,
                        principalTable: "funcoes",
                        principalColumn: "id_funcao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "funcionariocargo",
                columns: table => new
                {
                    id_funcionario = table.Column<int>(type: "INTEGER", nullable: false),
                    id_cargo = table.Column<string>(type: "TEXT", nullable: false),
                    id_nivel_acesso = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionariocargo", x => new { x.id_funcionario, x.id_cargo, x.id_nivel_acesso });
                    table.ForeignKey(
                        name: "FK_funcionariocargo_cargos_id_cargo",
                        column: x => x.id_cargo,
                        principalTable: "cargos",
                        principalColumn: "id_cargo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_funcionariocargo_funcionarios_id_funcionario",
                        column: x => x.id_funcionario,
                        principalTable: "funcionarios",
                        principalColumn: "id_funcionario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_funcionariocargo_niveisacesso_id_nivel_acesso",
                        column: x => x.id_nivel_acesso,
                        principalTable: "niveisacesso",
                        principalColumn: "id_nivel_acesso");
                });

            migrationBuilder.CreateTable(
                name: "funcaopermissao",
                columns: table => new
                {
                    id_funcao = table.Column<int>(type: "INTEGER", nullable: false),
                    id_permissao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcaopermissao", x => new { x.id_funcao, x.id_permissao });
                    table.ForeignKey(
                        name: "FK_funcaopermissao_funcoes_id_funcao",
                        column: x => x.id_funcao,
                        principalTable: "funcoes",
                        principalColumn: "id_funcao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_funcaopermissao_permissoes_id_permissao",
                        column: x => x.id_permissao,
                        principalTable: "permissoes",
                        principalColumn: "id_permissao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "colheita",
                columns: table => new
                {
                    id_colheita = table.Column<int>(type: "INTEGER", nullable: false),
                    id_funcionario = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    data = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "NULL"),
                    descricao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    id_produto = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colheita", x => x.id_colheita);
                    table.ForeignKey(
                        name: "FK_colheita_funcionarios_id_funcionario",
                        column: x => x.id_funcionario,
                        principalTable: "funcionarios",
                        principalColumn: "id_funcionario");
                    table.ForeignKey(
                        name: "FK_colheita_produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produtos",
                        principalColumn: "id_produto");
                });

            migrationBuilder.CreateTable(
                name: "estoque",
                columns: table => new
                {
                    id_estoque = table.Column<int>(type: "INTEGER", nullable: false),
                    id_insumo = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    tipo_item = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    data_entrada = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "NULL"),
                    id_produto = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    data_saida = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoque", x => x.id_estoque);
                    table.ForeignKey(
                        name: "FK_estoque_insumos_id_insumo",
                        column: x => x.id_insumo,
                        principalTable: "insumos",
                        principalColumn: "id_insumo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estoque_produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produtos",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movimentacao",
                columns: table => new
                {
                    id_movimentacao = table.Column<int>(type: "INTEGER", nullable: false),
                    id_insumo = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    tipo_item = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    tipo_movimentacao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    id_produto = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    data = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimentacao", x => x.id_movimentacao);
                    table.ForeignKey(
                        name: "FK_movimentacao_insumos_id_insumo",
                        column: x => x.id_insumo,
                        principalTable: "insumos",
                        principalColumn: "id_insumo");
                    table.ForeignKey(
                        name: "FK_movimentacao_produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produtos",
                        principalColumn: "id_produto");
                });

            migrationBuilder.CreateTable(
                name: "culturasperdidas",
                columns: table => new
                {
                    id_cultura_perdida = table.Column<int>(type: "INTEGER", nullable: false),
                    id_plantio = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    descricao = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    data = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_culturasperdidas", x => x.id_cultura_perdida);
                    table.ForeignKey(
                        name: "FK_culturasperdidas_plantio_id_plantio",
                        column: x => x.id_plantio,
                        principalTable: "plantio",
                        principalColumn: "id_plantio");
                });

            migrationBuilder.CreateTable(
                name: "produtosvendidos",
                columns: table => new
                {
                    id_produto_vendido = table.Column<int>(type: "INTEGER", nullable: false),
                    id_venda = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    id_produto = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: true, defaultValueSql: "NULL"),
                    data_venda = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "NULL"),
                    valor_total = table.Column<decimal>(type: "DECIMAL(10,0)", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtosvendidos", x => x.id_produto_vendido);
                    table.ForeignKey(
                        name: "FK_produtosvendidos_produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produtos",
                        principalColumn: "id_produto");
                    table.ForeignKey(
                        name: "FK_produtosvendidos_vendas_id_venda",
                        column: x => x.id_venda,
                        principalTable: "vendas",
                        principalColumn: "id_venda");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cargofuncao_id_funcao",
                table: "cargofuncao",
                column: "id_funcao");

            migrationBuilder.CreateIndex(
                name: "IX_colheita_id_funcionario",
                table: "colheita",
                column: "id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_colheita_id_produto",
                table: "colheita",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_compras_id_fornecedor",
                table: "compras",
                column: "id_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_compras_id_funcionario",
                table: "compras",
                column: "id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_contasreceber_id_cliente",
                table: "contasreceber",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_culturasperdidas_id_plantio",
                table: "culturasperdidas",
                column: "id_plantio");

            migrationBuilder.CreateIndex(
                name: "IX_estoque_id_insumo",
                table: "estoque",
                column: "id_insumo");

            migrationBuilder.CreateIndex(
                name: "IX_estoque_id_produto",
                table: "estoque",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_funcaopermissao_id_permissao",
                table: "funcaopermissao",
                column: "id_permissao");

            migrationBuilder.CreateIndex(
                name: "IX_funcionariocargo_id_cargo",
                table: "funcionariocargo",
                column: "id_cargo");

            migrationBuilder.CreateIndex(
                name: "IX_funcionariocargo_id_nivel_acesso",
                table: "funcionariocargo",
                column: "id_nivel_acesso");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_usuario",
                table: "funcionarios",
                column: "usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimentacao_id_insumo",
                table: "movimentacao",
                column: "id_insumo");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacao_id_produto",
                table: "movimentacao",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_ordemcompra_id_fornecedor",
                table: "ordemcompra",
                column: "id_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_plantio_id_funcionario",
                table: "plantio",
                column: "id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_produtosvendidos_id_produto",
                table: "produtosvendidos",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_produtosvendidos_id_venda",
                table: "produtosvendidos",
                column: "id_venda");

            migrationBuilder.CreateIndex(
                name: "IX_vendas_id_cliente",
                table: "vendas",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_vendas_id_funcionario",
                table: "vendas",
                column: "id_funcionario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cargofuncao");

            migrationBuilder.DropTable(
                name: "colheita");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "contasreceber");

            migrationBuilder.DropTable(
                name: "culturasperdidas");

            migrationBuilder.DropTable(
                name: "estoque");

            migrationBuilder.DropTable(
                name: "funcaopermissao");

            migrationBuilder.DropTable(
                name: "funcionariocargo");

            migrationBuilder.DropTable(
                name: "movimentacao");

            migrationBuilder.DropTable(
                name: "ordemcompra");

            migrationBuilder.DropTable(
                name: "produtosvendidos");

            migrationBuilder.DropTable(
                name: "plantio");

            migrationBuilder.DropTable(
                name: "funcoes");

            migrationBuilder.DropTable(
                name: "permissoes");

            migrationBuilder.DropTable(
                name: "cargos");

            migrationBuilder.DropTable(
                name: "niveisacesso");

            migrationBuilder.DropTable(
                name: "insumos");

            migrationBuilder.DropTable(
                name: "fornecedores");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "vendas");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "funcionarios");
        }
    }
}
