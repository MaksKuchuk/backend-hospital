using System;
using DataBase;
using DataBase.Repository;
using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Test.AppointmentTests;

public class AppointmentRepositoryTests
{
    private readonly DbContextOptionsBuilder<ApplicationContext> _optionsBuilder;

    public AppointmentRepositoryTests()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseNpgsql(
            $"Host=localhost;Port=5452;Database=exampleDB;Username=exampleUser;Password=examplePswd");
        _optionsBuilder = optionsBuilder;
    }
    
    [Fact]
    public void AddAppointment_InvalidAppointment_ShouldFail()
    {
        var context = new ApplicationContext(_optionsBuilder.Options);
        var appointmentRepository = new AppointmentRepository(context);
        
        var res = appointmentRepository.AddAppointment(
            new Appointment(Guid.Empty, Guid.Empty, Guid.Empty,
            new DateTime(2010, 10, 10, 13, 30, 00),
            new DateTime(2010, 10, 10, 12, 30, 00)));
        context.SaveChanges();
        
        Assert.False(res);
    }
}