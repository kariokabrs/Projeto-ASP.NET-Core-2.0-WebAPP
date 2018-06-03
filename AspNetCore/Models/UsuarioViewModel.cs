using AspNetCore.Classes;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Models
{
    public class UsuarioViewModel
    {
        public IQueryable<Usuario> Items { get; set; }
    }
}
