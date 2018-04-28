using System.Threading.Tasks;
using AspNetCore.Models;
using AspNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class UsuarioController : Controller
    {

        // Dependecy injection no controle Usuario
        // Para não haver erro de hierarquia e nível e para poder inicializar a Interface foi declarada publica. 
        private readonly IUsuarioService _Iusuario;

        public UsuarioController(IUsuarioService Iusuario)
        {
            // DI Pattern
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
       
        // Aqui declaro que o método é post sem precisar discriminar no chamador da View PartialViewNovoUsuario e dando o nome da ação em vez do método abaixo AddItemAsync para additem. 
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
                return new JsonResult("Não pode inserir um item");
            }
            return new JsonResult("Dados inseridos");
        }
    }
}