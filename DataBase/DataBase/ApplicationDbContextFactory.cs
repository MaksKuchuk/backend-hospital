using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataBase;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql
            ($"Host=localhost;Port=5452;Database=exampleDB;Username=exampleUser;Password=examplePswd");
        
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}