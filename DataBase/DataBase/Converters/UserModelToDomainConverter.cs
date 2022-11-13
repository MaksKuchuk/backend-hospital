using DataBase.Models;
using Hospital.Domain;

namespace DataBase.Converters;

public static class UserModelToDomainConverter
{
    public static User? ToDomain(this UserModel model)
    {
        return new User(model.Id, model.PhoneNumber, model.Name, model.Role);
    }
}