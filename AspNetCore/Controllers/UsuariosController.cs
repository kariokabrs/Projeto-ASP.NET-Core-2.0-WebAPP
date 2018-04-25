﻿using System.Threading.Tasks;
using AspNetCore.Models;
using AspNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class UsuariosController : Controller
    {

        // Dependecy injection no controle Usuario
        // Para não haver erro de hierarquia e nível a Interface foi declarada publica. 
        private readonly IUsuarioService _Iusuario;

        public UsuariosController(IUsuarioService Iusuario)
        {
            _Iusuario = Iusuario;
        }

        public async Task<IActionResult> Index()
        {

            var usuarios = await _Iusuario.GetUsuariosAsync();
            var model = new UsuarioViewModel() { Items = usuarios };

            if (usuarios == null)
            {
                Response.StatusCode = 200;
                return View("ProductNotFound");
            }

            return View("Views/Usuario/Usuario.cshtml");

        }
    }
}