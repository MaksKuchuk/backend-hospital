using Hospital.Domain;

namespace Hospital.Persistence.Validations;

public class DoctorValidation
{
    public static Result IsValid(Doctor doctor)
    {
        if (doctor.Name == string.Empty) return Result.Fail("Name error");

        var res = SpecializationValidation.IsValid(doctor.Specialization);
        if (res.IsFailure) return res;

        return Result.Ok();
    }
}