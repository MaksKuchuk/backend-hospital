using System;
using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.UseCases;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Test.ScheduleTests;

public class ScheduleServiceTests
{
    private readonly ScheduleService _scheduleService;
    private readonly Mock<IScheduleRepository> _scheduleRepositoryMock;

    public ScheduleServiceTests()
    {
        _scheduleRepositoryMock = new Mock<IScheduleRepository>();
        _scheduleService = new ScheduleService(_scheduleRepositoryMock.Object);
    }

    [Fact]
    public void ScheduleGet_ShouldFail()
    {
        _scheduleRepositoryMock.Setup(repository =>
                repository.GetScheduleByDoctorId(It.IsAny<Guid>(), It.IsAny<DateTime>()))
            .Returns(() => new Schedule(Guid.Empty, Guid.Empty,
                new DateTime(2010, 10, 10, 10, 10, 10),
                new DateTime(2010, 10, 10, 20, 10, 10)
                ));

        var res = _scheduleService.GetSchedule(Guid.Empty, new DateTime());
        
        Assert.True(res.Success);
    }
    
    [Fact]
    public void ScheduleAdd_ShouldFail()
    {
        _scheduleRepositoryMock.Setup(repository =>
                repository.AddScheduleById(It.IsAny<Guid>(), It.IsAny<Schedule>()))
            .Returns(() => false);

        var res = _scheduleService.AddSchedule(Guid.Empty, new Schedule(Guid.Empty, Guid.Empty,
            new DateTime(2010, 10, 10, 10, 10, 10),
            new DateTime(2010, 10, 10, 20, 10, 10)
        ));
        
        Assert.True(res.IsFailure);
        Assert.Equal("Cannot add a schedule", res.Error);
    }
    
    [Fact]
    public void ScheduleUpdate_ShouldFail()
    {
        _scheduleRepositoryMock.Setup(repository =>
                repository.UpdateScheduleById(It.IsAny<Guid>(), It.IsAny<Schedule>()))
            .Returns(() => false);

        var res = _scheduleService.UpdateSchedule(Guid.Empty, new Schedule(Guid.Empty, Guid.Empty,
            new DateTime(2010, 10, 10, 10, 10, 10),
            new DateTime(2010, 10, 10, 20, 10, 10)
        ));
        
        Assert.True(res.IsFailure);
        Assert.Equal("Cannot update a schedule", res.Error);
    }
}