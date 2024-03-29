using System.Dynamic;
using AutoMapper.Configuration.Conventions;
using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.Validations;

namespace Hospital.Persistence.UseCases;

public class AppointmentService
{
    private IAppointmentRepository _db;
    private readonly MutexSingleton _mutexSingleton = MutexSingleton.getInstance();

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

        if (!_mutexSingleton.getMutexAppointnetn().ContainsKey(appointment.DoctorId)) {
            _mutexSingleton.getMutexAppointnetn().Add(appointment.DoctorId, new Mutex());
        }
        _mutexSingleton.getMutexAppointnetn().First(d => d.Key == appointment.DoctorId).Value.WaitOne();
        
        if (_db.AddAppointment(appointment))
        {
            _mutexSingleton.getMutexAppointnetn().First(d => d.Key == appointment.DoctorId).Value.ReleaseMutex();
            return Result.Ok();
        }
        
        _mutexSingleton.getMutexAppointnetn().First(d => d.Key == appointment.DoctorId).Value.ReleaseMutex();
        return Result.Fail("Cannot add an appointment");
    }

    public Result<Appointment> AddToFreeDoctor(Specialization specialization)
    {
        if (SpecializationValidation.IsValid(specialization).IsFailure)
            return Result.Fail<Appointment>("Specialization error");
        
        var res = _db.GetAllAppointmentBySpecialization(specialization);

        if (res.Count == 0) return Result.Fail<Appointment>("There is not free doctors");

        var app = AddToDoctor(res[0]);

        if (app.IsFailure) return Result.Fail<Appointment>(app.Error);
        
        return Result.Ok(res[0]);
    }

    public Result<List<DateTime>> GetAllFree(Specialization specialization)
    {
        if (SpecializationValidation.IsValid(specialization).IsFailure)
            return Result.Fail<List<DateTime>>("Specialization error");
        
        var res = _db.GetAllAppointmentBySpecialization(specialization);
        var resDate = new List<DateTime>();

        for (var i = 0; i < res.Count; i++)
        {
            resDate.Add(res[i].StartTime);
        }

        return Result.Ok(resDate);
    }
}