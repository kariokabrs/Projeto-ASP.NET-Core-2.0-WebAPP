using AspNetCore.Classes;
using AspNetCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Services
{
    public interface IUsuarioService
    {
        // Criar um método que o UsuarioService deve herdar
        Task<IQueryable<Usuario>> GetUsuariosAsync();
        Task<bool> AddItemAsync(UsuarioModel newItem);
    }
}
