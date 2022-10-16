using System.Dynamic;
using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.Validations;

namespace Hospital.Persistence.UseCases;

public class AppointmentService
{
    private IAppointmentRepository _db;

    public AppointmentService(IAppointmentRepository db)
    {
        _db = db;
    }

    public Result AddToDoctor(Appointment? appointment)
    {
        if (appointment is null || AppointmentValidation.IsValid(appointment).IsFailure)
        {
            return Result.Fail("Invalid appointment");
        }
        
        if (_db.AddAppointment(appointment))
        {
            return Result.Ok();
        }
        
        return Result.Fail("Cannot add appointment");
    }

    public Result<Appointment> AddToFreeDoctor(Specialization specialization)
    {
        var res = GetAll(specialization);

        if (res.IsFailure) return Result.Fail<Appointment>("Get error");

        if (res.Value?.Count == 0) return Result.Fail<Appointment>("There is not free doctors");

        var app = AddToDoctor(res.Value?[0]);

        if (app.IsFailure) return Result.Fail<Appointment>(app.Error);
        
        return Result.Ok(res.Value[0]);
    }

    public Result<List<Appointment>> GetAll(Specialization specialization)
    {
        if (SpecializationValidation.IsValid(specialization).IsFailure)
            return Result.Fail<List<Appointment>>("Specialization error");
        
        var res = _db.GetAllAppointmentBySpecialization(specialization);

        return Result.Ok(res);
    }
}