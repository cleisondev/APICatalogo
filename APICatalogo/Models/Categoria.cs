using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

[Table("Categorias")]
public class Categoria
{
    public Categoria() 
    { 
        Produtos = new Collection<Produto>();
    }
    [Key] //Chave de identificação
    public int CategoriaId { get; set; }
    [Required]
    [StringLength(80)]//Tamanho maximo
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)]//Tamanho maximo
    public string? ImagemUrl { get; set; }
    public ICollection<Produto>? Produtos { get; set; } //Uma categoria pode ter muitos produtos, isso seria criar um FK no banco;

}
