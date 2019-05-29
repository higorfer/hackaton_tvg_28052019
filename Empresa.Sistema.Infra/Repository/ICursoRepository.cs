using Empresa.Sistema.Infra.DataAccessMySqlProvider.Repository.Generic;
using Empresa.Sistema.Infra.Model;
using RAG.Treinamentos.Model;
using System;
using System.Collections.Generic;

namespace Empresa.Sistema.Infra.Repository
{
    public interface ICursoRepository : IRepository<Curso>
    {
        List<Curso> FindByName(string firstName);

        List<AlunoCurso> AlunosPorCurso(string id, DateTime? dataInicial, DateTime? dataFinal);
    }
}
