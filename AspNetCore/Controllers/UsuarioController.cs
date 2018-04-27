using System.Threading.Tasks;
using AspNetCore.Models;
using AspNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class UsuarioController : Controller
    {

        // Dependecy injection no controle Usuario
        // Para não haver erro de hierarquia e nível a Interface foi declarada publica. 
        private readonly IUsuarioService _Iusuario;

        public UsuarioController(IUsuarioService Iusuario)
        {
            _Iusuario = Iusuario;
        }
       
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var usuarios = await _Iusuario.GetUsuariosAsync();
            var model = new UsuarioViewModel() { Items = usuarios };

            if (usuarios == null)
            {
                return View("Dados não encontrados");
            }

            return View("~/Views/Usuario/index.cshtml",model);

        }
       
        [HttpPost("additem")]
        public async Task<IActionResult> AddItemAsync(NovoUsuariomodel novoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var successful = await _Iusuario.AddItemAsync(novoUsuario);
            if (!successful) 
{
                return BadRequest(new { error = "Could	not	add	item" });
            }
            return Ok();
        }
    }
}