using DataBase.Models;
using Hospital.Domain;

namespace DataBase.Converters;

public static class ScheduleModelToDomainConverter
{
    public static Schedule ToDomain(this ScheduleModel model)
    {
        return new Schedule(model.Id, model.DoctorId, model.DayStart, model.DayEnd);
    }
}