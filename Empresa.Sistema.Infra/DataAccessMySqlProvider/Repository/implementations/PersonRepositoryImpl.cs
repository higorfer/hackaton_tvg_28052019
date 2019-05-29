using Empresa.Sistema.Infra.DataAccessMySqlProvider.Context;
using Empresa.Sistema.Infra.DataAccessMySqlProvider.Repository.Generic;
using Empresa.Sistema.Infra.Model;
using System.Collections.Generic;
using System.Linq;

namespace Empresa.Sistema.Infra.Repository.implementations
{
    public class PersonRepositoryImpl : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepositoryImpl(MySQLContext context) : base(context) { }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            }
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.LastName.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();
            }
            return _context.Persons.ToList();
        }
    }
}