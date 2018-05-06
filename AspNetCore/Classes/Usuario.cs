using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Classes
{

    public class Usuario
    {

        // POCO 
        // So deve usar o atributo KEY abaixo se a entidade não se chama ID ou Nome da classe seguido de ID: UsuarioID. 
        // Aqui coloquei apenas para o aprendizado
        [Key]
        public int Id { get; set; }
        // essa regex indica que só pode ser letras e sem espaçamento em branco. 
        
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }
   
        [MaxLength(80)]
        public string Sobrenome { get; set; }
        public DateTimeOffset? DiaCadastro { get; set; }
    }

}
