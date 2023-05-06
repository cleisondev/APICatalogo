using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

public class AppDbContext : DbContext // Tem que herdar da DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)//Configurar o contexto pra classe base
    {}

    //Mapeando as entidades pra gerar as tabelas no banco 
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produto>? Produtos { get; set; } 
}
