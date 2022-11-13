using DataBase.Models;
using Hospital.Domain;

namespace DataBase.Converters;

public static class AppointmentModelToDomainConverter
{
    public static Appointment ToDomain(this AppointmentModel model)
    {
        return new Appointment(model.Id, model.DoctorId, model.PatientId, model.StartTime, model.EndTime);
    }
}