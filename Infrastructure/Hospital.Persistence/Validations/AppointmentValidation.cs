using Hospital.Domain;

namespace Hospital.Persistence.Validations;

public class AppointmentValidation
{
    public static Result IsValid(Appointment appointment)
    {
        if (DateTime.Compare(appointment.StartTime, appointment.EndTime) >= 0)
        {
            return Result.Fail("Invalid time");
        }

        return Result.Ok();
    }
}