using Empresa.Sistema.Domain.Data.VO;

namespace Empresa.Sistema.Domain.Business.Interfaces
{
    public interface ILoginBusiness
    {
        object FindByLogin(UserVO user);
    }
}
