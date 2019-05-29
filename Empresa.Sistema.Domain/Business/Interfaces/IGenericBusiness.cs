using Empresa.Sistema.Domain.Data.VO;
using Empresa.Sistema.Infra.Model;
using RAG.Treinamentos.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Tapioca.HATEOAS.Utils;

namespace Empresa.Sistema.Domain.Business.Interfaces
{
    public interface IGenericBusiness<T> where T: BaseEntity
    {
        T Create(T entity);
        T FindById(string id);
        List<T> FindAll();
      
        T Update(T entity);
        void Delete(string id);
        PagedSearchDTO<T> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);



    }
}
