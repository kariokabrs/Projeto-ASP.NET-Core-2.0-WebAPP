using AspNetCore.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Services
{
    public class UsuarioService : IUsuarioService
    {
        public Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            // Retorna o array de usuários										
            IEnumerable<Usuario> itens = new[]
            {
                new Usuario
                {
                    Nome   =   "Sergio",
                    DiaCadastro   =   DateTimeOffset.Now.AddDays(1)
                },
                new Usuario
                {
                    Nome   =   "Carlos",
                    DiaCadastro   =   DateTimeOffset.Now.AddDays(2)
                }
            };
            return Task.FromResult(itens);
        }
    }
}
