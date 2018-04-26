﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Classes

{
    public class Usuario
    {
       // POCO 
       // Short way para um  full property
       // public bool Feito { get => _Feito; set => _Feito = value; }

        public int Id { get; set; }
        public bool Feito { get; set ; }
        public string Nome { get; set; }
        public DateTimeOffset? DiaCadastro { get; set; }
    }
}
