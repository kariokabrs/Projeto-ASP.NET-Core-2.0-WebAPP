using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class NovoUsuariomodel
    {
        [Required]
        [MaxLength(80)]
        // Aqui posso usar o Remote para verificar se algum email já está existente no banco de dados para não haver repetição com isso chamo o método ValidateNome no UsuarioController para validar. 
        //[Remote("ValidateNome", "Usuario")]
        public string Nome { get; set; }
    }
}
