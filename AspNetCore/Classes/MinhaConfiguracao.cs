using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Classes
{
    //Classe para alterar algumas configurações do sistema sem precisar sair no Source Control assim não se pode ver o source control da página como foram feitas e quais sçao as configurações. 
    public class MinhaConfiguracao
    {
        public string MenuBarBgColor { get; set; } = "black";
        public string MenuBarColor { get; set; } = "green";
    }
}
