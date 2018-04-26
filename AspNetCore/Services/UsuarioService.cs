using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Classes;
using AspNetCore.DBCoontext;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Services
{
    public class UsuarioService : IUsuarioService 
    {

        private readonly LibraryContext _context;

        public UsuarioService(LibraryContext context)
        {
            _context = context;
        }

        // Novo método agora usando o banco de dados Core criado pelo codeFirst.
        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            var items = await _context.Usuarios.Where(x => x.Feito == false).ToArrayAsync();
            return items;
        }

            /// Método usado sem o banco de dados. 
            //public Task<IEnumerable<Usuario>> GetUsuariosAsync()
            //{
            //    // Retorna o array de usuários										
            //    IEnumerable<Usuario> items = new[]
            //    {
            //    new Usuario
            //    {
            //        Nome   =   "Sergio",
            //        DiaCadastro   =   DateTimeOffset.Now.AddDays(1)
            //    },
            //    new Usuario
            //    {
            //        Nome   =   "Carlos",
            //        DiaCadastro   =   DateTimeOffset.Now.AddDays(2)
            //    }
            //};
            //    return Task.FromResult(items);
            //}
    }
}
