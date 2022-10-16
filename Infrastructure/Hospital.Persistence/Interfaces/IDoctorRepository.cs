using Hospital.Application.Interfaces;
using Hospital.Domain;

namespace Hospital.Persistence.Interfaces;

public interface IDoctorRepository : IRepository<Doctor>
{
    bool CreateDoctor(Doctor doctor);
    bool IsDoctorExists(Guid doctor);
    bool DeleteDoctor(Guid id);
    List<Doctor> GetDoctors();
    Doctor GetDoctorById(Guid id);
}