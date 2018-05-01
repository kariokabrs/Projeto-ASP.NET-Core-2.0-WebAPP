using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class NovoUsuariomodel
    {
 
        [Required]
        [MaxLength(80)]
        [Remote("ValidateNome", "Usuario")]
        public string Nome { get; set; }
    }
}
