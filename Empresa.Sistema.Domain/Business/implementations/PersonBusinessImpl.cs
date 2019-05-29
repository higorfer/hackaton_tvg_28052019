using AutoMapper;
using Empresa.Sistema.Domain.Business.Interfaces;
using Empresa.Sistema.Domain.Data.VO;
using Empresa.Sistema.Infra.Model;
using Empresa.Sistema.Infra.Repository;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace Empresa.Sistema.Domain.Business.implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private readonly IMapper _mapper;

        private IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            //_converter = new PersonConverter();
            _mapper = mapper;
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _mapper.Map<Person>(person);
            return _mapper.Map<PersonVO>(_repository.Create(personEntity));
        }

        public PersonVO FindById(long id)
        {
            return _mapper.Map<PersonVO>(_repository.FindById(id.ToString()));
        }

        public List<PersonVO> FindAll()

        {
            //var persons = _converter.ParseList(_repository.FindAll());

            return _mapper.Map<List<Person>, List<PersonVO>>(_repository.FindAll()); 
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _mapper.Map<List<Person>, List<PersonVO>>(_repository.FindByName(firstName, lastName));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _mapper.Map<Person>(person);
            personEntity = _repository.Update(personEntity);
            return _mapper.Map<PersonVO>(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id.ToString());
        }

        public PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;
            string query = @"select * from Persons p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) query = query + $" and p.firstName like '%{name}%'";

            query = query + $" order by p.firstName {sortDirection} limit {pageSize} offset {page}";

            string countQuery = @"select count(*) from Persons p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" and p.firstName like '%{name}%'";

           var pessoas = _repository.FindWithPagedSearch(query);

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchDTO<PersonVO>
            {
                CurrentPage = page + 1,
                List = _mapper.Map<List<Person>, List<PersonVO>>(pessoas),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }
        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }
    }
}
