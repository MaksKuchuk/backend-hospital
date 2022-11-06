using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.Validations;

namespace Hospital.Persistence.UseCases;

public class DoctorService
{
    private IDoctorRepository _db;

    public DoctorService(IDoctorRepository db)
    {
        _db = db;
    }

    public Result<Doctor> Add(Doctor doctor)
    {
        if (DoctorValidation.IsValid(doctor).IsFailure)
        {
            return Result.Fail<Doctor>("Invalid Doctor");
        }

        if (_db.CreateDoctor(doctor))
        {
            return Result.Ok(doctor);
        }

        return Result.Fail<Doctor>("Cannot add a doctor");
    }

    public Result<bool> IsExists(Guid id)
    {
        if (_db.IsDoctorExists(id))
        {
            return Result.Ok(true);
        }

        return Result.Ok(false);
    }

    public Result<bool> DeleteById(Guid id)
    {
        if (!IsExists(id).Value)
        {
            return Result.Fail<bool>("Doctor doesn't exist");
        }

        if (_db.DeleteDoctor(id))
        {
            return Result.Ok(true);
        }

        return Result.Fail<bool>("Cannot delete a doctor");
    }
    
    public Result<List<Doctor>> GetAll()
    {
        var list = _db.GetDoctors();

        return Result.Ok(list);
    }

    public Result<Doctor> GetById(Guid id)
    {
        if (!IsExists(id).Value)
        {
            return Result.Fail<Doctor>("Doctor doesn't exist");
        }

        var doctor = _db.GetDoctorById(id);
        if (DoctorValidation.IsValid(doctor).Success)
        {
            return Result.Ok(doctor);
        }
        
        return Result.Fail<Doctor>("Cannot get a doctor by id");
    }
}