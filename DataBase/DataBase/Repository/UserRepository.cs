using DataBase.Converters;
using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.Validations;

namespace DataBase.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(User item)
    {
        if (UserValidation.IsValid(item).IsFailure) return;
        
        _context.Users.Add(item.ToModel());
    }

    public void Update(User item)
    {
        if (UserValidation.IsValid(item).IsFailure) return;
        
        _context.Update(item.ToModel());
    }

    public void Delete(Guid id)
    {
        var user = GetItem(id);
        if (UserValidation.IsValid(user).IsFailure) return;

        _context.Remove(user);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.Select(model => model.ToDomain());
    }

    public User GetItem(Guid Id)
    {
        return _context.Users.FirstOrDefault(model => model.Id == Id).ToDomain();
    }

    public bool IsUserExists(string login)
    {
        if (login == "") return false;
        return _context.Users.Any(model => model.PhoneNumber == login);
    }

    public User FindUserByLogin(string login)
    {
        return _context.Users.FirstOrDefault(model => model.PhoneNumber == login).ToDomain();
    }

    public bool CreateUser(User user)
    {
        if (UserValidation.IsValid(user).IsFailure) return false;
        Create(user);
        return true;
    }
}