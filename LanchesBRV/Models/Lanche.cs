using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesBRV.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [Display(Name = "Nome do lanche")]
        [Required(ErrorMessage = "Informe o nome do lanche")]
        [MinLength(8, ErrorMessage = "O nome deve possuir no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve possuir no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição (curta)")]
        [Required(ErrorMessage = "Informe uma descrição curta")]
        [MinLength(10, ErrorMessage = "Descrição curta deve possuir no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "Descrição curta deve possuir no máximo {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Display(Name = "Descrição (detalhada)")]
        [Required(ErrorMessage = "Informe uma descrição detalhada")]
        [MinLength(30, ErrorMessage = "Descrição detalhada deve possuir no mínimo {1} caracteres")]
        [MaxLength(250, ErrorMessage = "Descrição detalhada deve possuir no máximo {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Informe o preço")]
        [Column(TypeName = "decimal(10,2)")] // Define o formato para o campo
        [Range(1,999.99, ErrorMessage= "O valor deve estar entre R$1 e R$999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        // Propriedades de navegação para definição do relacionamento
        public int CategoriaId { get; set; } // Foreign Key
        public virtual Categoria Categoria { get; set; }

    }
}
