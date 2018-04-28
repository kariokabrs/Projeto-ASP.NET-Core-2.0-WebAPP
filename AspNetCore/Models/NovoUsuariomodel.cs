using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class NovoUsuariomodel
    {
        // Atributo requerido. 
        [Required]
        [Display(Name = "Usuario")]
        public string Nome { get; set; }
    }
}
