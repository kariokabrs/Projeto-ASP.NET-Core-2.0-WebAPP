using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class NovoUsuariomodel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string Nome { get; set; }
    }
}
