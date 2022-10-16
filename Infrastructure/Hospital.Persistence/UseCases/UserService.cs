using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.Validations;

namespace Hospital.Persistence.UseCases;

public class UserService
{
    private IUserRepository _db;
    
    public UserService(IUserRepository db)
    {
        _db = db;
    }
    
    public Result<bool> IsExists(string login)
    {
        if (login == string.Empty)
        {
            return Result.Fail<bool>("Login input error");
        }

        if (_db.IsUserExists(login))
        {
            return Result.Ok(true);
        }

        return Result.Ok(false);
    }

    public Result<User> Register(User user)
    {
        if (UserValidation.IsValid(user).IsFailure)
        {
            return Result.Fail<User>("Invalid user form");
        }
        
        if (_db.CreateUser(user))
        {
            return Result.Ok(user);
        }

        return Result.Fail<User>("Cannot create user");
    }

    public Result<User> FindByLogin(string login)
    {
        if (login == string.Empty)
        {
            return Result.Fail<User>("Login input error");
        }
        
        if (_db.IsUserExists(login))
        {
            return Result.Ok(_db.FindUserByLogin(login));
        }
        
        return Result.Fail<User>("User doesn't exist");
    }
}