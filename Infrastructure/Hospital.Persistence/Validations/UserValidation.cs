using Hospital.Domain;
using Hospital.Persistence.Interfaces;

namespace Hospital.Persistence.Validations;

public class UserValidation
{
    public static Result IsValid(User user)
    {
        if (user.Name == string.Empty) return Result.Fail("Name error");
        if (user.PhoneNumber == string.Empty) return Result.Fail("Phone number error");

        return Result.Ok();
    }
}