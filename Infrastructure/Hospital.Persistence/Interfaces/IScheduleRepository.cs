using Hospital.Domain;

namespace Hospital.Persistence.Interfaces;

public interface IScheduleRepository
{
    Schedule GetScheduleById(Guid id, DateTime time);
    bool AddScheduleById(Guid id, Schedule schedule);
    bool UpdateScheduleById(Guid id, Schedule schedule);
}