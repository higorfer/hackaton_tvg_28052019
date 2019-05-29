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
    public interface IAlunoBusinessLogic : IGenericBusiness<Aluno>
    {

        List<Aluno> FindByName(string firstName, string lastName);

        List<Curso> CursosPorAluno(string id, DateTime? dataInicial, DateTime? dataFinal);


    }
}
