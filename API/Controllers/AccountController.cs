using Common.Account;
using Common.Response;
using Services.InterfaceImplementation;
using System.Web.Http;

namespace API.Controllers
{
    public class AccountController : ApiController
    {
        private AccountServices _acountServices;
        Response _response;
        public AccountController(AccountServices ac)
        {
            _acountServices = ac;
        }
        /// <summary>
        /// Create New user
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        [HttpPost]
        public Response Register(CreateUser createUser)
        {
            _response= _acountServices.CreateUser(createUser);
            return _response;
        }
    }
}
