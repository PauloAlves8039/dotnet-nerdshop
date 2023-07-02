using System.ComponentModel.DataAnnotations;

namespace NerdShop.WebApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name = "Nome")]
        public string CategoryName { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é de 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
