using Hospital.Domain;

namespace Hospital.Persistence.Validations;

public class SpecializationValidation
{
    public static Result IsValid(Specialization specialization)
    {
        if (specialization.Name == string.Empty) return Result.Fail("Specialization name error");

        return Result.Ok();
    }
}