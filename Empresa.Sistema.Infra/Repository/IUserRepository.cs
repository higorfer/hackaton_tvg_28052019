using Empresa.Sistema.Infra.Model;

namespace Empresa.Sistema.Infra.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
