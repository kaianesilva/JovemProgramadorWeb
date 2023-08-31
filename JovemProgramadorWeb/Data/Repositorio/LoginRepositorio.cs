using JovemProgramadorWeb.Data.Repositorio.Interfaces;
using JovemProgramadorWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorWeb.Data.Repositorio
{
    public class LoginRepositorio : ILoginRepositorio
    {



        private readonly BancoContexto _bancoContexto;



        public LoginRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public Login ValidarUsuario (Login login)
        {
            return _bancoContexto.Login.FirstOrDefault(x => x.email == login.email && x.senha == login.senha);
        }
    }


}