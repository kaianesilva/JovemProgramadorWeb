using JovemProgramadorWeb.Data.Repositorio;
using JovemProgramadorWeb.Data.Repositorio.Interfaces;
using JovemProgramadorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JovemProgramadorWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepositorio _loginRepositorio;
        public LoginController(ILoginRepositorio loginRepositorio)
        {
           
            _loginRepositorio = loginRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuscaLogin(Login login)
        {
            try
            {
               var acesso =  _loginRepositorio.ValidarUsuario(login);

                if (acesso != null)
                {
                     return RedirectToAction("Index","Home");
                }
                else 
                {
                    TempData["MsgErro"] = "Usuario ou senha incorretos! Tente Novamente!";
                }
            }
            catch (Exception)
            {

                TempData["MsgErro"] = "Erro ao buscar usuário!";
            }
            return View("Index");
        }
    }
}
