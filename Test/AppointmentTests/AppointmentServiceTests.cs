using System;
using System.Collections.Generic;
using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Xunit;
using Hospital.Persistence.UseCases;
using Moq;
using Xunit.Abstractions;

namespace Test.AppointmentTests;

public class AppointmentServiceTests
{
    private readonly AppointmentService _appointmentService;
    private readonly Mock<IAppointmentRepository> _appointmentRepositoryMock;

    public AppointmentServiceTests(ITestOutputHelper output)
    {
        _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
        _appointmentService = new AppointmentService(_appointmentRepositoryMock.Object);
    }

    [Fact]
    public void AppointmentAddToDoctor_ShouldFail()
    {
        _appointmentRepositoryMock.Setup(repository =>
                repository.AddAppointment(It.IsAny<Appointment>()))
            .Returns(() => false);

        var res = _appointmentService.AddToDoctor(new Appointment(
            Guid.Empty, Guid.Empty,
            new DateTime(2010, 1, 1, 1, 1, 1),
            new DateTime(2010, 1, 1, 2, 1, 1)
        ));
        
        Assert.True(res.IsFailure);
        Assert.Equal("Cannot add an appointment", res.Error);
    }
    
    [Fact]
    public void AppointmentAddToFreeDoctor_ShouldFail()
    {
        _appointmentRepositoryMock.Setup(repository =>
                repository.GetAllAppointmentBySpecialization(It.IsAny<Specialization>()))
            .Returns(() => new List<Appointment>(new Appointment[1]));
        
        _appointmentRepositoryMock.Setup(repository =>
                repository.AddAppointment(new Appointment(
                    Guid.Empty, Guid.Empty, 
                    new DateTime(2010, 1, 1, 1, 1, 1, 1),
                    new DateTime(2010, 1, 1, 2, 1, 1, 1)
                )))
            .Returns(() => true);

        var res = _appointmentService.AddToFreeDoctor(
            new Specialization("123"));

        Assert.True(res.IsFailure);
    }
    
    [Fact]
    public void AppointmentGetAll_ShouldFail()
    {
        var res = _appointmentService.GetAll(new Specialization("123"));
        
        Assert.True(res.Success);
    }
}