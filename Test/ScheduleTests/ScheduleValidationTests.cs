using System;
using Hospital.Domain;
using Hospital.Persistence.Validations;
using Xunit;
namespace Test.ScheduleTests;

public class ScheduleValidationTests
{
    private Schedule _timeSchedule;

    public ScheduleValidationTests()
    {
        _timeSchedule = new Schedule(Guid.Empty, Guid.Empty, 
            new DateTime(2010, 10, 10, 20, 10, 10),
            new DateTime(2010, 10, 10, 10, 10, 10)
            );
    }

    [Fact]
    public void ScheduleTimeIsWrong_ShouldFail()
    {
        var res = ScheduleValidation.IsValid(_timeSchedule);
        
        Assert.True(res.IsFailure);
        Assert.Equal("Invalid time", res.Error);
    }
}