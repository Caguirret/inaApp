using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddClienteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "tbCliente");

            migrationBuilder.RenameColumn(
                name: "precio",
                table: "tbProducto",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "tbProducto",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "descripcion",
                table: "tbProducto",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tbProducto",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "segundoApellido",
                table: "tbCliente",
                newName: "SegundoApellido");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_TipoIdentificacion_NumeroIdentificacion",
                table: "tbCliente",
                newName: "IX_tbCliente_TipoIdentificacion_NumeroIdentificacion");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "tbProducto",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "tbProducto",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "tbProducto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbCliente",
                table: "tbCliente",
                column: "IdClient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbCliente",
                table: "tbCliente");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "tbProducto");

            migrationBuilder.RenameTable(
                name: "tbCliente",
                newName: "Cliente");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "tbProducto",
                newName: "precio");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "tbProducto",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "tbProducto",
                newName: "descripcion");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbProducto",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SegundoApellido",
                table: "Cliente",
                newName: "segundoApellido");

            migrationBuilder.RenameIndex(
                name: "IX_tbCliente_TipoIdentificacion_NumeroIdentificacion",
                table: "Cliente",
                newName: "IX_Cliente_TipoIdentificacion_NumeroIdentificacion");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "tbProducto",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "tbProducto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "IdClient");
        }
    }
}
