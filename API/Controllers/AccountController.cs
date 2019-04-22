using Common.Account;
using Common.Response;
using Services.Interface;
using System.Linq;
using System.Web.Mvc;

namespace ApiTest
{
	public class RegisterController : Controller
	{


		private IAccountServices _acountServices;
		Response _response;
		public RegisterController(IAccountServices ac)
		{
			_acountServices = ac;
		}

		/// <summary>
		/// Create New user
		/// </summary>
		/// <param name="createUser"></param>
		/// <returns></returns></param>
		/// <returns></returns>
		[HttpPost]
		public Response Register(CreateUser createUser)
		{
			if (ModelState.IsValid)
			{
				createUser.validate();
				_response = _acountServices.CreateUser(createUser);
				
			}
			return _response;
		}
		/// <summary>
		/// update existing user
		/// </summary>
		/// <param name="updateUser"></param>
		/// <returns></returns>
		[HttpPost]
		public Response UpdateUser(UpdateUser updateUser)
		{
			_response = _acountServices.UpdateUser(updateUser);
			return _response;
		}
		/// <summary>
		/// Delete user
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		[HttpPost]
		public Response DeleteUser(long userId)
		{
			_response = _acountServices.DeleteUser(userId);
			return _response;
		}

	}
}
