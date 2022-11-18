using DataBase.Converters;
using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.Validations;

namespace DataBase.Repository;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationContext _context;

    public AppointmentRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public void Create(Appointment item)
    {
        if (AppointmentValidation.IsValid(item).IsFailure) return;
        
        _context.Appointments.Add(item.ToModel());
    }

    public void Update(Appointment item)
    {
        if (AppointmentValidation.IsValid(item).IsFailure) return;
        
        _context.Update(item.ToModel());
    }

    public void Delete(Guid id)
    {
        var appointment = GetItem(id);
        if (AppointmentValidation.IsValid(appointment).IsFailure) return;

        _context.Remove(appointment);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public IEnumerable<Appointment> GetAll()
    {
        return _context.Appointments.Select(model => model.ToDomain());
    }

    public Appointment GetItem(Guid Id)
    {
        return _context.Appointments.FirstOrDefault(model => model.Id == Id).ToDomain();
    }

    public bool AddAppointment(Appointment appointment)
    {
        if (AppointmentValidation.IsValid(appointment).IsFailure) return false;
        Create(appointment);
        return true;
    }

    public List<Appointment> GetAllAppointmentBySpecialization(Specialization specialization)
    {
        var enumDoctorsBySpecialization = _context.Doctors
            .Where(model => model.Specialization == specialization)
            .Select(model => model.ToDomain());

        var allDoctorId = new List<Guid>();
        foreach (var doctor in enumDoctorsBySpecialization)
        {
            if (!allDoctorId.Contains(doctor.Id))
            {
                allDoctorId.Add(doctor.Id);
            }
        }

        var listAppointmentsById = new List<IQueryable<Appointment>>();
        foreach (var doctorId in allDoctorId)
        {
            listAppointmentsById.Add(_context.Appointments
                .Where(model => model.DoctorId == doctorId).Select(model => model.ToDomain()));
        }

        var listAppointments = new List<Appointment>();
        foreach (var appointments in listAppointmentsById)
        {
            foreach (var appointment in appointments)
            {
                if (!listAppointments.Contains(appointment))
                {
                    listAppointments.Add(appointment);
                }
            }
        }

        return listAppointments;
    }
}