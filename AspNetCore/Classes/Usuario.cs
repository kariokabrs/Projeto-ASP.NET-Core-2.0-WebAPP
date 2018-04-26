using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Classes
{
    public class Usuario
    {
       // POCO 
       // Short way para um  full property
       // public bool Feito { get => _Feito; set => _Feito = value; }

        public Guid Id { get; set; }
        public bool Feito { get; set ; }

        //[Required]
        //[MinLength(2), MaxLength(80)]
        public string Nome { get; set; }

        //[Display(Name = "Dia do Cadastro")]
        //[DataType(DataType.DateTime)]
        public DateTimeOffset? DiaCadastro { get; set; }
    }
}
