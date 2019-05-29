using Empresa.Sistema.Domain.Business.Interfaces;
using Empresa.Sistema.Domain.Data.VO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.Sistema.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : Controller
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody]UserVO user)
        {
            if (user == null) return BadRequest();
            return _loginBusiness.FindByLogin(user);
        }
    }
}