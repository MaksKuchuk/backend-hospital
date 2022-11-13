using Hospital.Domain;

namespace Hospital.Application.Interfaces;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetItem(Guid id);
    void Create(T item);
    void Update(T item);
    void Delete(Guid id);
    void Save();
}

