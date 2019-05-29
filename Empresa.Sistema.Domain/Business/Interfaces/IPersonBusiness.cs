using Empresa.Sistema.Domain.Data.VO;
using Empresa.Sistema.Infra.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Tapioca.HATEOAS.Utils;

namespace Empresa.Sistema.Domain.Business.Interfaces
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        List<PersonVO> FindByName(string fristName, string lastName);
        PersonVO Update(PersonVO person);
        void Delete(long id);
        PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
