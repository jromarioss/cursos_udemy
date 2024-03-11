using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                "Values('Coca-Cola','Refrigerante 2l',8.99,'bebidas.jpg',100,now(),1)");
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                "Values('Pudim','Pudim de leite moça',18.89,'pudim.jpg',10,now(),3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
