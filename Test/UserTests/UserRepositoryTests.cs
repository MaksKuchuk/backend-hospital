using System;
using DataBase;
using DataBase.Repository;
using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class UserRepositoryTests
{
    private readonly DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

    public UserRepositoryTests()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(
            $"Host=localhost;Port=5452;Database=exampleDB;Username=exampleUser;Password=examplePswd");
        _optionsBuilder = optionsBuilder;
    }

    [Fact]
    public void CreateUser_InvalidUser_ShouldFail()
    {
        var context = new ApplicationDbContext(_optionsBuilder.Options);
        var userRepository = new UserRepository(context);
        
        var res = userRepository.CreateUser(new User(Guid.Empty, "", "", Role.Admin));
        context.SaveChanges();
        
        Assert.False(res);
    }

    [Fact]
    public void IsUserExists_InvalidLogin_ShouldFail()
    {
        var context = new ApplicationDbContext(_optionsBuilder.Options);
        var userRepository = new UserRepository(context);

        var res = userRepository.IsUserExists("");

        Assert.False(res);
    }

}