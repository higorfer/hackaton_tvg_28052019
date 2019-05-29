using Empresa.Sistema.Infra.DataAccessMySqlProvider.Context;
using Empresa.Sistema.Infra.DataAccessMySqlProvider.Repository.Generic;
using Empresa.Sistema.Infra.Model;
using RAG.Treinamentos.Model;
using System.Collections.Generic;
using System.Linq;
 

namespace Empresa.Sistema.Infra.Repository.implementations
{
    public class MatriculaRepository : GenericRepository<Matricula>, IMatriculaRepository
    {

        public MatriculaRepository(MySQLContext context) : base(context) { }


        public List<Matricula> FindByCursoId(string idCurso)
        {
            return this._context.Matriculas.Where(m => m.IdCurso == idCurso).ToList();
        }


        public List<Matricula> FindByAlunoId(string idAluno)
        {
            return this._context.Matriculas.Where(m => m.IdAluno == idAluno).ToList();
        }


        public void Delete(string idCurso, string idAluno)
        {
            //return dataset.FromSql<T>(query).ToList();      

        }


    }
}