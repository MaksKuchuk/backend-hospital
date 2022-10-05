using Microsoft.EntityFrameworkCore;
using Hospital.Application.Interfaces;
using Hospital.Domain;
using Hospital.Persistence.EntityTypeConfigurations;

namespace Hospital.Persistence;
public class UsersDbContext : DbContext, IUsersDbContext {
  public DbSet<User> Users { get; set; };
  
  public UsersDbContext(DbContextOptions<UsersDbContext> options)
  : base(options) { };

  protected override void OnModelCreating(ModelBuilder builder) {
    builder.ApplyConfiguration(new UserConfiguration());
    base.OnModelCreating(builder);
  }
}