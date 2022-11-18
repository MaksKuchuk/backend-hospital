using System;
using Hospital.Domain;
using Hospital.Persistence.Validations;
using Xunit;
namespace Test.AppointmentTests;

public class AppointmentValidationTests
{
    private Appointment _timeAppointment;

    public AppointmentValidationTests()
    {
        _timeAppointment = new Appointment(Guid.Empty, Guid.Empty, Guid.Empty,
            new DateTime(2010, 10, 10, 13, 30, 00),
            new DateTime(2010, 10, 10, 12, 30, 00));
    }

    [Fact]
    public void AppointmentTimeIsWrong_ShouldFail()
    {
        var res = AppointmentValidation.IsValid(_timeAppointment);
        
        Assert.True(res.IsFailure);
        Assert.Equal("Invalid time", res.Error);
    }
}