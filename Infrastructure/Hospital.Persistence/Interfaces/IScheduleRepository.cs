using Hospital.Application.Interfaces;
using Hospital.Domain;

namespace Hospital.Persistence.Interfaces;

public interface IScheduleRepository : IRepository<Schedule>
{
    Schedule GetScheduleByDoctorId(Guid id, DateTime time);
    bool AddScheduleById(Guid id, Schedule schedule);
    bool UpdateScheduleById(Guid id, Schedule schedule);
}