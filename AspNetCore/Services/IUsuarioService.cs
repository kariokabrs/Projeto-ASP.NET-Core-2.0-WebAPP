using AspNetCore.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Services
{
    public interface IUsuarioService
    {
        // Criar um método que o UsuarioService deve herdar
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
    }
}
