using Empresa.Sistema.Infra.Model.Base;
using RAG.Treinamentos.Model;
using System.Collections.Generic;

namespace Empresa.Sistema.Infra.DataAccessMySqlProvider.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(string id);
        List<T> FindAll();
        T Update(T item);
        void Delete(string id);

        bool Exists(long? id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
