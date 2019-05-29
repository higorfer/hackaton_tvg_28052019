using AutoMapper;
using Empresa.Sistema.Domain.Business.Interfaces;

using Empresa.Sistema.Infra.Model;
using Empresa.Sistema.Infra.Repository;
using RAG.Treinamentos.Model;
using System;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace Empresa.Sistema.Domain.Business.implementations
{
    public class AlunoBusinessLogic : IAlunoBusinessLogic
    {
        private readonly IMapper _mapper;

        private IAlunoRepository _repository;

        public AlunoBusinessLogic(IAlunoRepository repository, IMapper mapper)
        {
            _repository = repository;
            //_converter = new AlunoConverter();
            _mapper = mapper;
        }

        public Aluno Create(Aluno Aluno)
        {
            var AlunoEntity = _mapper.Map<Aluno>(Aluno);
            return _mapper.Map<Aluno>(_repository.Create(AlunoEntity));
        }

        public Aluno FindById(string id)
        {
            return _mapper.Map<Aluno>(_repository.FindById(id.ToString()));
        }

        public List<Aluno> FindAll()

        {
            //var Alunos = _converter.ParseList(_repository.FindAll());

            return _mapper.Map<List<Aluno>, List<Aluno>>(_repository.FindAll());
        }

        public List<Aluno> FindByName(string firstName, string lastName)
        {
            return _mapper.Map<List<Aluno>, List<Aluno>>(_repository.FindByName(firstName, lastName));
        }

        public Aluno Update(Aluno Aluno)
        {
            var AlunoEntity = _mapper.Map<Aluno>(Aluno);
            AlunoEntity = _repository.Update(AlunoEntity);
            return _mapper.Map<Aluno>(AlunoEntity);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public PagedSearchDTO<Aluno> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;
            string query = @"select * from Alunos p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) query = query + $" and p.firstName like '%{name}%'";

            query = query + $" order by p.firstName {sortDirection} limit {pageSize} offset {page}";

            string countQuery = @"select count(*) from Alunos p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" and p.firstName like '%{name}%'";

            var pessoas = _repository.FindWithPagedSearch(query);

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchDTO<Aluno>
            {
                CurrentPage = page + 1,
                List = _mapper.Map<List<Aluno>, List<Aluno>>(pessoas),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }

        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }

        public List<Curso> CursosPorAluno(string id, DateTime? dataInicial, DateTime? dataFinal)
        {
            return this._repository.CursosPorAluno(id, dataInicial, dataFinal);
        }
    }
}
