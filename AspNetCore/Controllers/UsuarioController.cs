using System.Linq;
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
        // Aquilo coloco o atributo Route para configurar meu erro personalizado na Startup Class.
        //[Route("/Error")]
        // Se eu precisar usar o Service IsuarioService em apenas um Método, não preciso declarar na contrução da classe apens colcoar um atributo como parametro. 
        //public async Task<IActionResult> Index([FromServices] IUsuarioService Isuario)
        public async Task<IActionResult> Index()
        {
            UsuarioViewModel model = new UsuarioViewModel();

            // Se eu não quiser chamar a DI no construtor, _IUsuario eu posso fazer dentro do metódo de forma dependente o seguinte, o que não é recomendado:
            //var services = this.HttpContext.RequestServices;
            //var log = (IUsuarioService)services.GetService(typeof(IUsuarioService));

            var usuarios = await _Iusuario.GetUsuariosAsync();
            // aqui coloco o resultado do Metodo Getusuarios = usuarios e coloco na ViewModel, model definida instanciada acima. 
            model.Items = usuarios;

            // Aqui declaro o parametro da View visto esta uma pasta fora de Home, sua Path e sua ViewModel. 

            //Console.WriteLine("~/Views/Usuario/index.cshtml");
            return View("~/Views/Usuario/index.cshtml", model);

        }

        // Aqui declaro que o método é post sem precisar discriminar no chamador da View PartialViewNovoUsuario e dando o nome da ação em vez do método abaixo AddItemAsync para additem. 
        [HttpPost("additem")]
        //[Route("/Error")]
        // implementar [ValidateAntiForgeryToken]
        // usar [Bind(nameof(NovoUsuariomodel.Nome))] para evitar ataque Mass assignment, também conhecido como Over-posting
        public async Task<IActionResult> AddItem([Bind(nameof(NovoUsuariomodel.Nome), nameof(NovoUsuariomodel.Sobrenome))] NovoUsuariomodel novoUsuario)
        {
            if (await TryUpdateModelAsync(novoUsuario))
            {
                await _Iusuario.AddItemAsync(novoUsuario);

                // Aqui retorno após inserir novo usuário JsonResult onde a string cairá no SPAN id=msg da PartialViewNovoUsuario. 
                return RedirectToAction("Index");

                // Aqui para retornar uma nova view ususario ou pelo nome do método do controller Usuario
                //return RedirectToRoute("usuario");
                //return RedirectToAction(nameof(Index));
            }
            else
            {
                // Aqui contruo uma variavel que me retornará o erro diretamente do ModelState sem precisar redirecionar ou chamar novamente a View() e coloco o valor como forma de JsonResult. 
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToList();

                return new JsonResult(errorList);
            }

        }
        //Metodo chamado pelo REMOTE da ViewModel NovoUsuariomodel de ida e volta ao servidor
        //[AcceptVerbs("Get", "Post")]
        //public IActionResult ValidateNome(string nome)
        //{
        //    if (nome == "")
        //    {
        //        return Json(data: "O campo nome não pode estar em branco!");
        //    }
        //    else
        //    {
        //        return Json(data: true);
        //    }

        //}
        public JsonResult Resultado()
        {
            return new JsonResult("Dados Inseridos");
        }

    }

}