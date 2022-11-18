using DataBase.Models;
using Hospital.Domain;

namespace DataBase.Converters;

public static class DoctorModelToDomainConverter
{
    public static Doctor ToDomain(this DoctorModel model)
    {
        return new Doctor(model.Id, model.Name, model.Specialization);
    }
}