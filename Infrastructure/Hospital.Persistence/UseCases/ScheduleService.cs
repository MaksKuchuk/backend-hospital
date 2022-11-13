using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.Validations;

namespace Hospital.Persistence.UseCases;

public class ScheduleService
{
    private IScheduleRepository _db;

    public ScheduleService(IScheduleRepository db)
    {
        _db = db;
    }

    public Result<Schedule> GetSchedule(Guid id, DateTime time)
    {
        var res = _db.GetScheduleByDoctorId(id, time);

        if (ScheduleValidation.IsValid(res).IsFailure) 
            return Result.Fail<Schedule>("Invalid schedule");
        
        return Result.Ok(res);
    }

    public Result AddSchedule(Guid id, Schedule schedule)
    {
        if (ScheduleValidation.IsValid(schedule).IsFailure)
            return Result.Fail("Invalid schedule");

        if (_db.AddScheduleById(id, schedule))
        {
            return Result.Ok();
        }

        return Result.Fail("Cannot add a schedule");
    }

    public Result UpdateSchedule(Guid id, Schedule schedule)
    {
        if (ScheduleValidation.IsValid(schedule).IsFailure)
            return Result.Fail("Invalid schedule");

        if (_db.UpdateScheduleById(id, schedule))
        {
            return Result.Ok();
        }

        return Result.Fail("Cannot update a schedule");
    }
}