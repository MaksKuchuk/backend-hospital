using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hospital.Domain;

namespace Hospital.Application.Interfaces;
public interface IUsersDbContext {
  DbSet<User> Users { get; set; }
  Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}