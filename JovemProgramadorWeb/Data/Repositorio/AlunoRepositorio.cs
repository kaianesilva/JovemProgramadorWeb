using JovemProgramadorWeb.Data.Repositorio.Interfaces;
using JovemProgramadorWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorWeb.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {



        private readonly BancoContexto _bancoContexto;



        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }



        public List<Aluno> BuscarAlunos()
        {
            return _bancoContexto.Aluno.ToList();
        }

        public void InserirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
        }

        public void ExcluirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Remove(aluno);
            _bancoContexto.SaveChanges();
        }

        public void Editar(Aluno aluno)
        {
            _bancoContexto.Aluno.Update(aluno);
            _bancoContexto.SaveChanges();
        }

        public Aluno ListarPorId(int id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(x => x.id == id);
        }

        public Aluno Atualizar(Aluno aluno)
        {
            Aluno alunoDB = ListarPorId(aluno.id);


            if (alunoDB == null) throw new System.Exception("Erro");

            alunoDB.nome = aluno.nome;
            alunoDB.idade = aluno.idade;
            alunoDB.matricula = aluno.matricula;
            alunoDB.cep = aluno.cep;

            _bancoContexto.Aluno.Update(alunoDB);
            _bancoContexto.SaveChanges();

            return alunoDB;
        }

        public bool Apagar(int id)
        {
            Aluno alunoDB = ListarPorId(id);
            if (alunoDB == null) throw new System.Exception("Erro");
            _bancoContexto.Aluno.Remove(alunoDB);
            _bancoContexto.SaveChanges();
            return true;
        }




    }
}
