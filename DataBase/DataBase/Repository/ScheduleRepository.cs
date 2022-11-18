using DataBase.Converters;
using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.Validations;

namespace DataBase.Repository;

public class ScheduleRepository : IScheduleRepository
{
    private readonly ApplicationContext _context;

    public ScheduleRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public void Create(Schedule item)
    {
        if (ScheduleValidation.IsValid(item).IsFailure) return;
        
        _context.Schedules.Add(item.ToModel());
    }

    public void Update(Schedule item)
    {
        if (ScheduleValidation.IsValid(item).IsFailure) return;
        
        _context.Update(item.ToModel());
    }

    public void Delete(Guid id)
    {
        var schedule = GetItem(id);
        if (ScheduleValidation.IsValid(schedule).IsFailure) return;

        _context.Remove(schedule);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public IEnumerable<Schedule> GetAll()
    {
        return _context.Schedules.Select(model => model.ToDomain());
    }

    public Schedule GetItem(Guid Id)
    {
        return _context.Schedules.FirstOrDefault(model => model.Id == Id).ToDomain();
    }

    public Schedule GetScheduleByDoctorId(Guid doctorId, DateTime time)
    {
        return _context.Schedules.FirstOrDefault(
            model => model.DoctorId == doctorId && model.DayStart == time).ToDomain();
    }

    public bool AddScheduleById(Guid doctorId, Schedule schedule)
    {
        schedule.DoctorId = doctorId;
        if (ScheduleValidation.IsValid(schedule).IsFailure || doctorId == Guid.Empty) return false;
        Create(schedule);
        return true;
    }

    public bool UpdateScheduleById(Guid doctorId, Schedule schedule)
    {
        schedule.DoctorId = doctorId;
        if (ScheduleValidation.IsValid(schedule).IsFailure || doctorId == Guid.Empty) return false;
        Update(schedule);
        return true;
    }
}