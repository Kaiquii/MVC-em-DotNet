using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cadastro.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é requerido.")]
        [Range(0.01, 999999999, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Value { get; set; }

        [Display(Name = "Ativo")]
        public bool Active { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "O cliente é requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione um cliente.")]
        public int IdClient { get; set; }

        [Display(Name = "Cliente")]
        public string ClientName { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "A categoria é requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione uma categoria.")]
        public int IdCategory { get; set; }

        [Display(Name = "Categoria")]
        public string CategoryName { get; set; }

        public IEnumerable<SelectListItem> Clients { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
