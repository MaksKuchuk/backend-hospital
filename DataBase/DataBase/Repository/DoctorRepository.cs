using DataBase.Converters;
using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.Validations;

namespace DataBase.Repository;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationContext _context;

    public DoctorRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public void Create(Doctor item)
    {
        if (DoctorValidation.IsValid(item).IsFailure) return;
        
        _context.Doctors.Add(item.ToModel());
    }

    public void Update(Doctor item)
    {
        if (DoctorValidation.IsValid(item).IsFailure) return;
        
        _context.Update(item.ToModel());
    }

    public void Delete(Guid id)
    {
        var doctor = GetItem(id);
        if (DoctorValidation.IsValid(doctor).IsFailure) return;

        _context.Remove(doctor);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public IEnumerable<Doctor> GetAll()
    {
        return _context.Doctors.Select(model => model.ToDomain());
    }

    public Doctor GetItem(Guid Id)
    {
        return _context.Doctors.FirstOrDefault(model => model.Id == Id).ToDomain();
    }

    public bool CreateDoctor(Doctor doctor)
    {
        Create(doctor);
        return true;
    }

    public bool IsDoctorExists(Guid Id)
    {
        return _context.Doctors.Any(model => model.Id == Id);
    }

    public bool DeleteDoctor(Guid id)
    {
        if (!IsDoctorExists(id)) return false;
        Delete(id);
        return true;
    }

    public List<Doctor> GetDoctors()
    {
        var list = GetAll();
        return list.ToList();
    }

    public Doctor GetDoctorById(Guid Id)
    {
        return _context.Doctors.FirstOrDefault(model => model.Id == Id).ToDomain();
    }
}