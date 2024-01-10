using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalago.Migrations;

public partial class PopulandoATabelaCategoria : Migration
{
    protected override void Up(MigrationBuilder mb)
    {
        mb.Sql("Insert into Categorias(Name, ImagemUrl) Values('Lanches', 'lanches.jpg')");
        mb.Sql("Insert into Categorias(Name, ImagemUrl) Values('Sobremesas', 'sobremesas.jpg')");
    }

    protected override void Down(MigrationBuilder mb)
    {
        mb.Sql("Delete from Categorias");
    }
}
