using JovemProgramadorWeb.Data.Repositorio;
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

        public IActionResult Editar(int id)
        {
            Aluno aluno = _alunoRepositorio.ListarPorId(id);
            return View(aluno);
        }

        public IActionResult Alterar(Aluno aluno)
        {
            _alunoRepositorio.Atualizar(aluno);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            _alunoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            Aluno aluno = _alunoRepositorio.ListarPorId(id);
            return View(aluno);
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

        public IActionResult ExcluirAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.ExcluirAluno(aluno);
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = "Erro ao deletar aluno!";
            }

            TempData["MsgAcerto"] = "Aluno deletado com sucesso!";

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
