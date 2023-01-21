using Hospital.Domain;

namespace DataBase.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Name { get; set; }
    public Role Role { get; set; }

    public string Pass { get; set; }
}