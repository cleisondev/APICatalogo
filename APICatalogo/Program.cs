using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace APICatalogo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var mysqlconnection = builder.Configuration.GetConnectionString("DefaultConnection");//Obtendo string de conexao

            //Registro do contexto do EF Core no conteiner de inativo
            builder.Services.AddEntityFrameworkMySql()
                         .AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}