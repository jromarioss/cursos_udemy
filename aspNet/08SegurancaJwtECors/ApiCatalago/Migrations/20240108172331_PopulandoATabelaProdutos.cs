using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalago.Migrations;

public partial class PopulandoATabelaProdutos : Migration
{
    protected override void Up(MigrationBuilder mb)
    {
        mb.Sql("Insert into Produtos(Name,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                "Values('Coca-Cola','Refrigerante 2 litros',8.99,'bebidas.jpg',100,now(),1)");
        mb.Sql("Insert into Produtos(Name,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
            "Values('Pudim','Pudim 250 gramas',18.89,'pudim.jpg',10,now(),3)");
    }

    protected override void Down(MigrationBuilder mb)
    {
        mb.Sql("Delete from Produtos");
    }
}
