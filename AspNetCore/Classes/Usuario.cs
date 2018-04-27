using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Classes

{
    public class Usuario
    {

       // POCO 
       
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }
        [Required]     
        public DateTimeOffset? DiaCadastro { get; set; }
    }
}
