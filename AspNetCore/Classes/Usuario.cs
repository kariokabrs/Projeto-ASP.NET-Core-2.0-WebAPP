using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AspNetCore.Classes

{
    [DataContract(Name = "Usuarios", Namespace = "http:/alphabetacom.wordpres.com")]
    public class Usuario
    {

        // POCO 
        [DataMember(Name = "ID")]
        [Key]
        public int Id { get; set; }
        [DataMember(Name = "Usuario Nome")]
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }
        [JsonIgnore]   
        public DateTimeOffset? DiaCadastro { get; set; }
    }
}
