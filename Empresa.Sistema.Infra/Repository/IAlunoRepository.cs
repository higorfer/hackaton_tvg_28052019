using Empresa.Sistema.Infra.DataAccessMySqlProvider.Repository.Generic;
using Empresa.Sistema.Infra.Model;
using RAG.Treinamentos.Model;
using System;
using System.Collections.Generic;

namespace Empresa.Sistema.Infra.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        List<Aluno> FindByName(string firstName, string lastName);

        List<Curso> CursosPorAluno(string id, DateTime? dataInicial, DateTime? dataFinal);
    }
}
