using Empresa.Sistema.Domain.Data.VO;
using Empresa.Sistema.Infra.Model;
using RAG.Treinamentos.Domain.Model;
using RAG.Treinamentos.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Tapioca.HATEOAS.Utils;

namespace Empresa.Sistema.Domain.Business.Interfaces
{
    public interface ICursoBusinessLogic : IGenericBusiness<Curso>
    {
        List<Curso> FindByName(string firstName);

        //CursoModel Create(CursoModel person);
        //CursoModel FindById(string id);
        //List<CursoModel> FindAll();
        //List<CursoModel> FindByName(string fristName);
        //CursoModel Update(CursoModel person);
        //void Delete(string id);
        //PagedSearchDTO<CursoModel> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);

        List<AlunoCurso> AlunosPorCurso(string id, DateTime? dataInicial, DateTime? dataFinal);
    }
}
