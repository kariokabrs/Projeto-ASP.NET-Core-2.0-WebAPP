using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class NovoUsuariomodel
    {
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}
