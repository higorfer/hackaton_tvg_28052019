using Empresa.Sistema.Domain.Data.VO;
using Empresa.Sistema.Infra.Model;
using RAG.Treinamentos.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Tapioca.HATEOAS.Utils;

namespace Empresa.Sistema.Domain.Business.Interfaces
{
    public interface IMatriculaBusinessLogic : IGenericBusiness<Matricula>
    {

        List<Matricula> FindByCursoId(string idCurso);


        List<Matricula> FindByAlunoId(string idAluno);


       void Delete(string idCurso, string idAluno);

    }
}
