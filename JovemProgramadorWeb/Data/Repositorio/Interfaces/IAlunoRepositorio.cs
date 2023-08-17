using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAlunos();

        void InserirAluno(Aluno aluno);

        void ExcluirAluno(Aluno aluno);

        void Editar(Aluno aluno);

        Aluno ListarPorId(int id);
        Aluno Atualizar(Aluno aluno);

        bool Apagar(int id);


    }
}
