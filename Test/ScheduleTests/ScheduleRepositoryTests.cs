using System;
using DataBase;
using DataBase.Repository;
using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace Test.ScheduleTests;
public class ScheduleRepositoryTests
{
    private readonly DbContextOptionsBuilder<ApplicationContext> _optionsBuilder;

    public ScheduleRepositoryTests()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseNpgsql(
            $"Host=localhost;Port=5452;Database=exampleDB;Username=exampleUser;Password=examplePswd");
        _optionsBuilder = optionsBuilder;
    }

    [Fact]
    public void UpdateScheduleById_InvalidSchedule_ShouldFail()
    {
        var context = new ApplicationContext(_optionsBuilder.Options);
        var scheduleRepository = new ScheduleRepository(context);

        var res = scheduleRepository.UpdateScheduleById(Guid.NewGuid(),
            new Schedule(Guid.Empty, Guid.Empty,
                new DateTime(2010, 10, 10, 20, 10, 10),
                new DateTime(2010, 10, 10, 10, 10, 10)
            ));
        context.SaveChanges();
        
        Assert.False(res);
    }
    
    [Fact]
    public void UpdateScheduleById_InvalidId_ShouldFail()
    {
        var context = new ApplicationContext(_optionsBuilder.Options);
        var scheduleRepository = new ScheduleRepository(context);

        var res = scheduleRepository.UpdateScheduleById(Guid.Empty,
            new Schedule(Guid.NewGuid(), Guid.NewGuid(),
                new DateTime(2010, 10, 10, 10, 10, 10),
                new DateTime(2010, 10, 10, 20, 10, 10)
            ));
        context.SaveChanges();
        
        Assert.False(res);
    }

    [Fact]
    public void AddScheduleById_InvalidSchedule_ShouldFail()
    {
        var context = new ApplicationContext(_optionsBuilder.Options);
        var scheduleRepository = new ScheduleRepository(context);

        var res = scheduleRepository.AddScheduleById(Guid.NewGuid(),
            new Schedule(Guid.Empty, Guid.Empty,
                new DateTime(2010, 10, 10, 20, 10, 10),
                new DateTime(2010, 10, 10, 10, 10, 10)
            ));
        context.SaveChanges();
        
        Assert.False(res);
    }
    
    [Fact]
    public void AddScheduleById_InvalidId_ShouldFail()
    {
        var context = new ApplicationContext(_optionsBuilder.Options);
        var scheduleRepository = new ScheduleRepository(context);

        var res = scheduleRepository.AddScheduleById(Guid.Empty,
            new Schedule(Guid.NewGuid(), Guid.NewGuid(),
                new DateTime(2010, 10, 10, 10, 10, 10),
                new DateTime(2010, 10, 10, 20, 10, 10)
            ));
        context.SaveChanges();
        
        Assert.False(res);
    }
}