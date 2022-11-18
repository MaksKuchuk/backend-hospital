using DataBase.Models;
using Hospital.Domain;

namespace DataBase.Converters;

public static class DoctorDomainToModelConverter
{
    public static DoctorModel ToModel(this Doctor doctor)
    {
        return new DoctorModel
        {
            Id = doctor.Id,
            Name = doctor.Name,
            Specialization = doctor.Specialization
        };
    }
}