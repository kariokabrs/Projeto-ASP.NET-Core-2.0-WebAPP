using System;
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
            // Para funcionar preciso Adcionar UsuarioService se  o EF core for utlizado sem uso do Extension Method. 
            _Iusuario = Iusuario;
        }
       
        [HttpGet]
        // Se eu precisar usar o Service IsuarioService em apenas um Método, não preciso declarar na contrução da classe apens colcoar um atributo como parametro. 
        //public async Task<IActionResult> Index([FromServices] IUsuarioService Isuario)
        public async Task<IActionResult> Index()
        {

            // Se eu não quiser chamar a DI no construtor, _IUsuario eu posso fazer dentro do metódo de forma dependente o seguite, o que não é recomendado:
            //var services = this.HttpContext.RequestServices;
            //var log = (IUsuarioService)services.GetService(typeof(IUsuarioService));

            var usuarios = await _Iusuario.GetUsuariosAsync();
            var model = new UsuarioViewModel() { Items = usuarios };

            if (usuarios == null)
            {
                return View("Dados não encontrados");
            }
            // Aqui declaro o parametro da View visto esta uma pasta fora de Home, sua Path e sua ViewModel. 

            //Console.WriteLine("~/Views/Usuario/index.cshtml");
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
            // Aqui retorno após inserir novo usuário JsonResult onde a string cairá no SPAN id=msg da PartialViewNovoUsuario. 

            return new JsonResult("Dados inseridos") ;
        }
    }
}