using DataBase.Models;
using Hospital.Domain;

namespace DataBase.Converters;

public static class UserDomainToModelConverter
{
    public static UserModel ToModel(this User user)
    {
        return new UserModel
        {
            Id = user.Id,
            PhoneNumber = user.PhoneNumber,
            Name = user.Name,
            Role = user.Role
        };
    }
}