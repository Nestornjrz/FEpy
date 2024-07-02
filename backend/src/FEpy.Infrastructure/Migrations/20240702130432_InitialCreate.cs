using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FEpy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mercaderias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreMercaderia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercaderias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OcurredOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeMovimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NombreTipoMovimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeMovimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspectores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumeroDeCedula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspectores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspectores_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SociosDeNegocios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ruc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SociosDeNegocios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SociosDeNegocios_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supervisores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumeroDeCedula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supervisores_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Depositos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreDeposito = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    DireccionDeposito = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SupervisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depositos_Supervisores_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Supervisores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepositosInspectores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepositoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InspectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositosInspectores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositosInspectores_Depositos_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "Depositos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositosInspectores_Inspectores_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositosMercaderias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepositoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MercaderiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositosMercaderias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositosMercaderias_Depositos_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "Depositos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositosMercaderias_Mercaderias_MercaderiaId",
                        column: x => x.MercaderiaId,
                        principalTable: "Mercaderias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositosSociosDeNegocios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepositoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocioDeNegocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositosSociosDeNegocios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositosSociosDeNegocios_Depositos_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "Depositos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositosSociosDeNegocios_SociosDeNegocios_SocioDeNegocioId",
                        column: x => x.SocioDeNegocioId,
                        principalTable: "SociosDeNegocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DepositoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocioDeNegocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MercaderiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDeMovimientoId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnidadDeMedida = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Depositos_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "Depositos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimiento_Mercaderias_MercaderiaId",
                        column: x => x.MercaderiaId,
                        principalTable: "Mercaderias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimiento_SociosDeNegocios_SocioDeNegocioId",
                        column: x => x.SocioDeNegocioId,
                        principalTable: "SociosDeNegocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimiento_TiposDeMovimientos_TipoDeMovimientoId",
                        column: x => x.TipoDeMovimientoId,
                        principalTable: "TiposDeMovimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposDeMovimientos",
                columns: new[] { "Id", "NombreTipoMovimiento" },
                values: new object[,]
                {
                    { 1, "Entrada" },
                    { 2, "Salida" },
                    { 3, "SinMovimiento" },
                    { 4, "Ajuste" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_NombreDeposito",
                table: "Depositos",
                column: "NombreDeposito",
                unique: true,
                filter: "[NombreDeposito] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_SupervisorId",
                table: "Depositos",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositosInspectores_DepositoId_InspectorId",
                table: "DepositosInspectores",
                columns: new[] { "DepositoId", "InspectorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepositosInspectores_InspectorId",
                table: "DepositosInspectores",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositosMercaderias_DepositoId_MercaderiaId",
                table: "DepositosMercaderias",
                columns: new[] { "DepositoId", "MercaderiaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepositosMercaderias_MercaderiaId",
                table: "DepositosMercaderias",
                column: "MercaderiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositosSociosDeNegocios_DepositoId_SocioDeNegocioId",
                table: "DepositosSociosDeNegocios",
                columns: new[] { "DepositoId", "SocioDeNegocioId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepositosSociosDeNegocios_SocioDeNegocioId",
                table: "DepositosSociosDeNegocios",
                column: "SocioDeNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspectores_NumeroDeCedula",
                table: "Inspectores",
                column: "NumeroDeCedula",
                unique: true,
                filter: "[NumeroDeCedula] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Mercaderias_NombreMercaderia",
                table: "Mercaderias",
                column: "NombreMercaderia",
                unique: true,
                filter: "[NombreMercaderia] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_DepositoId",
                table: "Movimiento",
                column: "DepositoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_MercaderiaId",
                table: "Movimiento",
                column: "MercaderiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_SocioDeNegocioId",
                table: "Movimiento",
                column: "SocioDeNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_TipoDeMovimientoId",
                table: "Movimiento",
                column: "TipoDeMovimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_SociosDeNegocios_Ruc",
                table: "SociosDeNegocios",
                column: "Ruc",
                unique: true,
                filter: "[Ruc] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisores_NumeroDeCedula",
                table: "Supervisores",
                column: "NumeroDeCedula",
                unique: true,
                filter: "[NumeroDeCedula] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeMovimientos_NombreTipoMovimiento",
                table: "TiposDeMovimientos",
                column: "NombreTipoMovimiento",
                unique: true,
                filter: "[NombreTipoMovimiento] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositosInspectores");

            migrationBuilder.DropTable(
                name: "DepositosMercaderias");

            migrationBuilder.DropTable(
                name: "DepositosSociosDeNegocios");

            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "OutboxMessages");

            migrationBuilder.DropTable(
                name: "Inspectores");

            migrationBuilder.DropTable(
                name: "Depositos");

            migrationBuilder.DropTable(
                name: "Mercaderias");

            migrationBuilder.DropTable(
                name: "SociosDeNegocios");

            migrationBuilder.DropTable(
                name: "TiposDeMovimientos");

            migrationBuilder.DropTable(
                name: "Supervisores");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
