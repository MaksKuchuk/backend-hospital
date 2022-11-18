using DataBase.Models;
using Hospital.Domain;

namespace DataBase.Converters;

public static class AppointmentDomainToModelConverter
{
    public static AppointmentModel ToModel(this Appointment appointment)
    {
        return new AppointmentModel
        {
            StartTime = appointment.StartTime,
            EndTime = appointment.EndTime,
            PatientId = appointment.PatientId,
            DoctorId = appointment.DoctorId
        };
    }
}