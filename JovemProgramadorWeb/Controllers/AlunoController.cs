using JovemProgramadorWeb.Data.Repositorio.Interfaces;
using JovemProgramadorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JovemProgramadorWeb.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;
        }

        public IActionResult Index()
        {
            var aluno = _alunoRepositorio.BuscarAlunos();
            return View(aluno);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult InserirAluno(Aluno aluno)
        {
            try 
            {
                _alunoRepositorio.InserirAluno(aluno);
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = "Erro ao inserir aluno!";
            }

            TempData["MsgAcerto"] = "Aluno inserido com sucesso!";

            return RedirectToAction("Index");
        
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            Endereco endereco = new Endereco();



            try
            {
                cep = cep.Replace("-", "");



                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");



                if (result.IsSuccessStatusCode)
                {
                    endereco = JsonSerializer.Deserialize<Endereco>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });
                    ViewData["MsgAcerto"] = "Endereço encontrado com sucesso!";
                }
                else
                {
                    ViewData["MsgErro"] = "Erro na busca do endereço!";
                }



            }
            catch (Exception)
            {



                throw;
            }


            

            return View("Endereco", endereco);

        }
    }
}
