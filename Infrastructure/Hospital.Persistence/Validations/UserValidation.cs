using Hospital.Domain;
using Hospital.Persistence.Interfaces;

namespace Hospital.Persistence.Validations;

public class UserValidation
{
    public static Result<bool> IsValid(User user)
    {
        if (user.Name == string.Empty) return Result.Ok(false);
        if (user.PhoneNumber == string.Empty) return Result.Ok(false);

        return Result.Ok(true);
    }
}