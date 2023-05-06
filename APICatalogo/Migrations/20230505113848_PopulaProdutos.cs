using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                "values('Coca-Cola','Regrigerante de Cola 350 ml',5.45,'cocacola.jpg',50,getdate(),1)");

            mb.Sql("insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
              "values('Lanche de Atum','Lanche de atum com maionese',8.50,'atum.jpg',20,getdate(),2)");

            mb.Sql("insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
             "values('Pudim 100 g','Pudim de leite condensado 100 g',6.75,'pudim.jpg',10,getdate(),3)");


        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Produtos");
        }
    }
}
