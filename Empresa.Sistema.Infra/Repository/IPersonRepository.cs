using Empresa.Sistema.Infra.DataAccessMySqlProvider.Repository.Generic;
using Empresa.Sistema.Infra.Model;
using System.Collections.Generic;

namespace Empresa.Sistema.Infra.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> FindByName(string fristName, string lastName);
    }
}
