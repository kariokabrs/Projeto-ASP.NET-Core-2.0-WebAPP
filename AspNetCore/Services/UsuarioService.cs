using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Classes;
using AspNetCore.DBCoontext;
using AspNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Services
{
    public class UsuarioService : IUsuarioService
    {

        // Dependecy Injection Pattern.
        // Declarar um readonly private e carregar no contrutor desta classe. 
        private readonly LibraryContext _context;

        public UsuarioService(LibraryContext context)
        {
            //DI Pattern
            _context = context;
        }

        // Novo método agora usando o banco de dados Core criado pelo codeFirst.
        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            var items = await _context.Usuarios.ToArrayAsync();
            return items;
        }

        public async Task<bool> AddItemAsync(NovoUsuariomodel novoUsuario)
        {
            var entity = new Usuario
            {
                Nome = novoUsuario.Nome,
                DiaCadastro = DateTimeOffset.Now.AddDays(3)
            };

            _context.Usuarios.Add(entity);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

    }
 
}

