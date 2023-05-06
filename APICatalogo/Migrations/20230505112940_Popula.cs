using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class Popula : Migration
    {
        protected override void Up(MigrationBuilder mb)//Inserindo dados na tabela
        {
            mb.Sql("insert into Categorias(Nome,ImagemUrl) values('Bebidas','bebidas.jpg')");
            mb.Sql("insert into Categorias(Nome,ImagemUrl) values('Lanches','lanches.jpg')");
            mb.Sql("insert into Categorias(Nome,ImagemUrl) values('Sobremesas','sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder mb)//Comando pra apagar caso precise
        {
            mb.Sql("delete from Categorias");
        }
    }
}
