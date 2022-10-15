using Hospital.Application.Interfaces;
using Hospital.Domain;

namespace Hospital.Persistence.Interfaces;

public interface IUserRepository : IRepository<User>
{
    bool IsUserExists(string login);
    User FindUserByLogin(string login);
    bool CreateUser(User user);
}