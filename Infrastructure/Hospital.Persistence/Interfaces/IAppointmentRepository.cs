using Hospital.Application.Interfaces;
using Hospital.Domain;

namespace Hospital.Persistence.Interfaces;

public interface IAppointmentRepository : IRepository<Appointment>
{
    bool AddAppointment(Appointment appointment);
    List<Appointment> GetAllAppointmentBySpecialization(Specialization specialization);
}