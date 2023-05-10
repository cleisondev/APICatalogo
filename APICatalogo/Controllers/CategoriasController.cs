using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CategoriasController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                return _dbContext.Categorias.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]//Pra usar o get passando o ID, eu coloco aqui no método, e :int restringe o tipo de valor
        public ActionResult<Categoria> Get(int id) //Passando o parametro Id que será usado pra buscar apenas por Id
        {

            try
            {
                var categoria = _dbContext.Categorias.FirstOrDefault(x => x.CategoriaId == id);//A variavel produtos ela vai pegar o primeiro Produto que tiver o Id igual ao do parametro
                if (categoria is null)
                {
                    return NotFound("Produto não encontrado");
                }

                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }

          
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
                return BadRequest();



            _dbContext.Categorias.Add(categoria);//Adicionando o novo produto ao contexto
            _dbContext.SaveChanges();//Salvando no contexto

            //Recomendado retornar o status 201 created, colocar no cabecario location da resposta HTTP a URL do novo recurso criado
            //Defino o nome, qual o Id do produto que no caso é o Id novo, e o produto em si.
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]//Implementando o ID pra procurar por ID
        public ActionResult Put(int id, Categoria categoria)//Id pra achar o produto e o Produto pra colocar o novo produto
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _dbContext.Entry(categoria).State = EntityState.Modified;//Definir o estado do contexto pra modificado
            _dbContext.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]//Passando Id na URL
        public ActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound($"Produto com id = {id} não localizado...");


            var categoria = _dbContext.Categorias.FirstOrDefault(x => x.CategoriaId == id);//Encontrando o produto pelo Id
            _dbContext.Categorias.Remove(categoria);//Removendo o  produto do banco
            _dbContext.SaveChanges();//Salvando no contexto

            return Ok(categoria);
        }




    }
}
