using Empresa.Sistema.Infra.DataAccessMySqlProvider.Repository.Generic;
using Empresa.Sistema.Infra.Model;
using RAG.Treinamentos.Model;
using System.Collections.Generic;

namespace Empresa.Sistema.Infra.Repository
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {

        List<Matricula> FindByCursoId(string idCurso);

        List<Matricula> FindByAlunoId(string idAluno);

        void Delete(string idCurso, string idAluno);
    }
}
