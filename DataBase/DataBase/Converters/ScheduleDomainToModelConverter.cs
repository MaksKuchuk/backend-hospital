using DataBase.Models;
using Hospital.Domain;

namespace DataBase.Converters;

public static class ScheduleDomainToModelConverter
{
    public static ScheduleModel ToModel(this Schedule schedule)
    {
        return new ScheduleModel
        {
            Id = schedule.Id,
            DoctorId = schedule.DoctorId,
            DayStart = schedule.DayStart,
            DayEnd = schedule.DayEnd
        };
    }
}