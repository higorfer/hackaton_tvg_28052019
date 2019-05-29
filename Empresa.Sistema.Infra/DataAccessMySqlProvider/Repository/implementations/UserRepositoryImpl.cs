using Empresa.Sistema.Infra.DataAccessMySqlProvider.Context;
using Empresa.Sistema.Infra.Model;
using Empresa.Sistema.Infra.Repository;
using System.Linq;

namespace Empresa.Sistema.Infra.DataAccessMySqlProvider.Repository.implementations
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
    }
}
