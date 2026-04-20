using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesBRV.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [MinLength(8, ErrorMessage= "O tamanho mínimo é de {1} caracteres")]
        [MaxLength(100, ErrorMessage= "O tamanho máximo é de {1} caracteres")]

        public string CategoriaNome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [MinLength(20, ErrorMessage = "O tamanho mínimo é de {1} caracteres")]
        [MaxLength(200, ErrorMessage = "O tamanho máximo é de {1} caracteres")]
        public string Descricao { get; set; }

        // Define o relacionamento com a categoria Lanche de 1 para muitos
        public List<Lanche> Lanches { get; set; }
    }
}
