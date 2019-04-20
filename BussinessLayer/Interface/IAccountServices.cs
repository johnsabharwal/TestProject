using Common.Account;
using Common.Response;

namespace Services.Interface
{
    public interface IAccountServices
    {
        Response CreateUser(CreateUser createUser);
    }
}
