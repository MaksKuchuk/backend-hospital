using System;
using DataBase;
using DataBase.Repository;
using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Test.DoctorTests;

public class DoctorRepositoryTests
{
    private readonly DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

    public DoctorRepositoryTests()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(
            $"Host=localhost;Port=5452;Database=exampleDB;Username=exampleUser;Password=examplePswd");
        _optionsBuilder = optionsBuilder;
    }
    
    [Fact]
    public void CreateDoctor_InvalidDoctor_ShouldFail()
    {
        var context = new ApplicationDbContext(_optionsBuilder.Options);
        var doctorRepository = new DoctorRepository(context);
        
        var res = doctorRepository.CreateDoctor(new Doctor(Guid.Empty, "", 
            new Specialization(Guid.Empty, "")));
        context.SaveChanges();
        
        Assert.False(res);
    }
    
    [Fact]
    public void IsDoctorExists_InvalidId_ShouldFail()
    {
        var context = new ApplicationDbContext(_optionsBuilder.Options);
        var doctorRepository = new DoctorRepository(context);
        
        var res = doctorRepository.IsDoctorExists(Guid.Empty);

        Assert.False(res);
    }
    
    [Fact]
    public void DeleteDoctor_InvalidId_ShouldFail()
    {
        var context = new ApplicationDbContext(_optionsBuilder.Options);
        var doctorRepository = new DoctorRepository(context);
        
        var res = doctorRepository.DeleteDoctor(Guid.Empty);

        Assert.False(res);
    }
}