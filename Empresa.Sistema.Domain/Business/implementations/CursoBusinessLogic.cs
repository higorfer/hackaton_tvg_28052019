using AutoMapper;
using Empresa.Sistema.Domain.Business.Interfaces;

using Empresa.Sistema.Infra.Model;
using Empresa.Sistema.Infra.Repository;
using RAG.Treinamentos.Domain.Model;
using RAG.Treinamentos.Model;
using System;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace Empresa.Sistema.Domain.Business.implementations
{
    public class CursoBusinessLogic : ICursoBusinessLogic
    {
        private readonly IMapper _mapper;

        private ICursoRepository _repository;

        public CursoBusinessLogic(ICursoRepository repository, IMapper mapper)
        {
            _repository = repository;
            //_converter = new CursoConverter();
            _mapper = mapper;


        }

        public Curso Create(Curso Curso)
        {
            var CursoEntity = _mapper.Map<Curso>(Curso);
            return _mapper.Map<Curso>(_repository.Create(CursoEntity));
        }

        public Curso FindById(string id)
        {
            return _mapper.Map<Curso>(_repository.FindById(id.ToString()));
        }

        public List<Curso> FindAll()
        {
            return _mapper.Map<List<Curso>, List<Curso>>(_repository.FindAll());
        }

        public List<Curso> FindByName(string name)
        {
            return _mapper.Map<List<Curso>, List<Curso>>(_repository.FindByName(name));
        }

        public Curso Update(Curso cursoModel)
        {
            var cursoEntity = _mapper.Map<Curso>(cursoModel);
            cursoEntity = _repository.Update(cursoEntity);
            return _mapper.Map<Curso>(cursoEntity);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public PagedSearchDTO<Curso> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;
            string query = @"select * from Cursos p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) query = query + $" and p.firstName like '%{name}%'";

            query = query + $" order by p.firstName {sortDirection} limit {pageSize} offset {page}";

            string countQuery = @"select count(*) from Cursos p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" and p.firstName like '%{name}%'";

            var pessoas = _repository.FindWithPagedSearch(query);

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchDTO<Curso>
            {
                CurrentPage = page + 1,
                List = _mapper.Map<List<Curso>, List<Curso>>(pessoas),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }
        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }

        public List<AlunoCurso> AlunosPorCurso(string id, DateTime? dataInicial, DateTime? dataFinal)
        {
            return this._repository.AlunosPorCurso(id, dataInicial, dataFinal);
        }
    }
}
