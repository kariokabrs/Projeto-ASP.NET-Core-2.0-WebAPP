using AspNetCore.Classes;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class UsuarioModel
    {
        // Aqui defino meu próprios erros em vez do gerado pelo ValidateModel do Ajax unobtrusive.
        [Required(ErrorMessage = "O nome não pode estar em branco")]
        [MaxLength(80,ErrorMessage = "Apenas 80 caracteres permitidos!")]
        [RegularExpression("^[a-zA-Z]+$")]
        [Display(Name = "Primeiro Nome")]
        // Aqui meu atributo que criei de forma personalidade da Classe NomePersonalizada Atributo. 
        [NomePersonalizada]
        // Aqui posso usar o Remote para verificar se algum email já está existente no banco de dados para não haver repetição com isso chamo o método ValidateNome no UsuarioController para validar. 
        //[Remote("ValidateNome", "Usuario", HttpMethod = "POST", ErrorMessage = "Nome não pode estar em branco.")]
        public string Nome { get; set; }

        [MaxLength(80, ErrorMessage = "Apenas 80 caracteres permitidos!")]
        [Display(Name = "Sobrenome Nome")]
        public string Sobrenome { get; set; }
    }
}
