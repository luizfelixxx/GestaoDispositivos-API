using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventoCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivo_Clientes_ClienteId",
                table: "Dispositivo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dispositivo",
                table: "Dispositivo");

            migrationBuilder.RenameTable(
                name: "Dispositivo",
                newName: "Dispositivos");

            migrationBuilder.RenameIndex(
                name: "IX_Dispositivo_ClienteId",
                table: "Dispositivos",
                newName: "IX_Dispositivos_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "Serial",
                table: "Dispositivos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IMEI",
                table: "Dispositivos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dispositivos",
                table: "Dispositivos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DispositivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Dispositivos_DispositivoId",
                        column: x => x.DispositivoId,
                        principalTable: "Dispositivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_Serial",
                table: "Dispositivos",
                column: "Serial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_DispositivoId",
                table: "Eventos",
                column: "DispositivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivos_Clientes_ClienteId",
                table: "Dispositivos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivos_Clientes_ClienteId",
                table: "Dispositivos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dispositivos",
                table: "Dispositivos");

            migrationBuilder.DropIndex(
                name: "IX_Dispositivos_Serial",
                table: "Dispositivos");

            migrationBuilder.RenameTable(
                name: "Dispositivos",
                newName: "Dispositivo");

            migrationBuilder.RenameIndex(
                name: "IX_Dispositivos_ClienteId",
                table: "Dispositivo",
                newName: "IX_Dispositivo_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "Serial",
                table: "Dispositivo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "IMEI",
                table: "Dispositivo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dispositivo",
                table: "Dispositivo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivo_Clientes_ClienteId",
                table: "Dispositivo",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
