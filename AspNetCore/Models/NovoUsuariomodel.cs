using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class NovoUsuariomodel
    {
        // Atributo requerido. 
        [Required]
        public string Nome { get; set; }
    }
}
