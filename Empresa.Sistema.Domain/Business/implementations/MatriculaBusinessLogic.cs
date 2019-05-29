using AutoMapper;
using Empresa.Sistema.Domain.Business.Interfaces;

using Empresa.Sistema.Infra.Model;
using Empresa.Sistema.Infra.Repository;
using RAG.Treinamentos.Model;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

using System.Linq;

namespace Empresa.Sistema.Domain.Business.implementations
{
    public class MatriculaBusinessLogic : IMatriculaBusinessLogic
    {
        private readonly IMapper _mapper;

        private IMatriculaRepository _repository;

        public MatriculaBusinessLogic(IMatriculaRepository repository, IMapper mapper)
        {
            _repository = repository;
            //_converter = new MatriculaConverter();
            _mapper = mapper;
        }

        public Matricula Create(Matricula Matricula)
        {
            var MatriculaEntity = _mapper.Map<Matricula>(Matricula);
            return _mapper.Map<Matricula>(_repository.Create(MatriculaEntity));
        }

        public Matricula FindById(string id)
        {
            return _mapper.Map<Matricula>(_repository.FindById(id.ToString()));
        }

        public List<Matricula> FindAll()

        {
            //var Matriculas = _converter.ParseList(_repository.FindAll());

            return _mapper.Map<List<Matricula>, List<Matricula>>(_repository.FindAll());
        }



        public Matricula Update(Matricula matricula)
        {
            return null;
            //var matriculaentity = _mapper.map<Matricula>(matricula);
            //matriculaentity = _repository.update(matriculaentity);
            //return _mapper.map<Matricula>(matriculaentity);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }
 
        public void Delete(string idCurso, string idAluno)
        {
            _repository.Delete(idCurso, idAluno);
        }

        public PagedSearchDTO<Matricula> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            return null;
            //page = page > 0 ? page - 1 : 0;
            //string query = @"select * from Matriculas p where 1 = 1 ";
            //if (!string.IsNullOrEmpty(name)) query = query + $" and p.firstName like '%{name}%'";

            //query = query + $" order by p.firstName {sortDirection} limit {pageSize} offset {page}";

            //string countQuery = @"select count(*) from Matriculas p where 1 = 1 ";
            //if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" and p.firstName like '%{name}%'";

            //var pessoas = _repository.FindWithPagedSearch(query);

            //int totalResults = _repository.GetCount(countQuery);

            //return new PagedSearchDTO<Matricula>
            //{
            //    CurrentPage = page + 1,
            //    List = _mapper.Map<List<Matricula>, List<Matricula>>(pessoas),
            //    PageSize = pageSize,
            //    SortDirections = sortDirection,
            //    TotalResults = totalResults
            //};
        }
        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }


        public List<Matricula> FindByCursoId(string idCurso)
        {           
            return _repository.FindByCursoId(idCurso);

            string query = @"SELECT ALU.* FROM ALUNO ALU";
            query = query + $" INNER JOIN MATRICULA MAT ON MAT.IdAluno = ALU.Id ";
            query = query + $" WHERE MAT.IdCurso =" + idCurso;
            //query = query + $ AND MAT.DATA BETWEEN "('2019/05/01') AND ('2019/05/28'); ";
            //if (!string.IsNullOrEmpty(name)) query = query + $" and p.firstName like '%{name}%'";


            //var pessoas = _repository.FindWithPagedSearch(query);

            //int totalResults = _repository.GetCount(countQuery);

            //return new PagedSearchDTO<Matricula>
            //{
            //    CurrentPage = page + 1,
            //    List = _mapper.Map<List<Matricula>, List<Matricula>>(pessoas),
            //    PageSize = pageSize,
            //    SortDirections = sortDirection,
            //    TotalResults = totalResults
            //};

        }


        public List<Matricula> FindByAlunoId(string idAluno)
        {
            return _repository.FindByAlunoId(idAluno);
        }








    }
}
