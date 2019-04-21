using Common.Account;
using Common.Response;

namespace Services.Interface
{
    public interface IAccountServices
    {
        Response CreateUser(CreateUser createUser);
        Response UpdateUser(UpdateUser createUser);
        Response DeleteUser(long UserId);

    }
}
