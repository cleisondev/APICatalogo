using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        //Primeiro definir uma variavel do tipo do contexto
        //Readonly pra não ser alterada após instanciada
        private readonly AppDbContext _dbContext;

        public ProdutosController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]//Afirmando o metodo
        public ActionResult<IEnumerable<Produto>> Get() //Se quero todas informações, recebo em formato de coleçao, por isso IEnumerable
        {

            var produtos = _dbContext.Produtos.ToList(); //Crio uma variavel, passo a variavel do contexto e de onde quero a info e mando em formato lista
            if(produtos is null)
            {
                return NotFound("Produtos não encontrados");//Tive que usar action result pra suportar o retorno de um tipo diferende de IEnumerable
            }
            
            return produtos;
        }

        [HttpGet("{id:int}", Name ="ObterProduto")]//Pra usar o get passando o ID, eu coloco aqui no método, e :int restringe o tipo de valor
        public ActionResult<Produto> Get(int id) //Passando o parametro Id que será usado pra buscar apenas por Id
        {
            var produto = _dbContext.Produtos.FirstOrDefault(x => x.ProdutoId == id);//A variavel produtos ela vai pegar o primeiro Produto que tiver o Id igual ao do parametro
            if(produto is null)
            {
                return NotFound("Produto não encontrado");
            }

            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if(produto is null)
                return BadRequest();
            
               

            _dbContext.Produtos.Add(produto);//Adicionando o novo produto ao contexto
            _dbContext.SaveChanges();//Salvando no contexto
            
            //Recomendado retornar o status 201 created, colocar no cabecario location da resposta HTTP a URL do novo recurso criado
            //Defino o nome, qual o Id do produto que no caso é o Id novo, e o produto em si.
            return new CreatedAtRouteResult("ObterProduto", new {id = produto.ProdutoId}, produto);
        }


    }
}
