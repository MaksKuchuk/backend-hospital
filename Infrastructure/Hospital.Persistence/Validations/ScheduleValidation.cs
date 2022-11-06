using Hospital.Domain;

namespace Hospital.Persistence.Validations;

public class ScheduleValidation
{
    public static Result IsValid(Schedule schedule)
    {
        if (DateTime.Compare(schedule.DayStart, schedule.DayEnd) >= 0)
        {
            return Result.Fail("Invalid time");
        }

        return Result.Ok();
    }
}