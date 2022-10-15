using Hospital.Domain;

namespace Hospital.Application.UseCases;

public class UserService
{
    public Result<bool> IsExists(string login)
    {
        return Result.Ok(true);
    }

    public Result<User> Register(User user)
    {
        return Result.Ok(user);
    }

    public Result<User> FindByLogin(string login)
    {
        return Result.Ok(new User());
    }
}