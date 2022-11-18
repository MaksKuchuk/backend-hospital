using System;
using System.Collections.Generic;
using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.UseCases;
using Xunit;
using Moq;
namespace Test.DoctorTests;

public class DoctorServiceTests
{
    private readonly DoctorService _doctorService;
    private readonly Mock<IDoctorRepository> _doctorRepositoryMock;

    public DoctorServiceTests()
    {
        _doctorRepositoryMock = new Mock<IDoctorRepository>();
        _doctorService = new DoctorService(_doctorRepositoryMock.Object);
    }

    [Fact]
    public void DoctorIsExists_ShouldFail()
    {
        _doctorRepositoryMock.Setup(repository => 
            repository.IsDoctorExists(It.IsAny<Guid>()))
            .Returns(() => false);
        
        var res = _doctorService.IsExists(Guid.Empty);
        
        Assert.False(res.Value);
    }

    [Fact]
    public void DoctorAdd_ShouldFail()
    {
        _doctorRepositoryMock.Setup(repository => 
                repository.CreateDoctor(It.IsAny<Doctor>()))
            .Returns(() => false);

        var res = _doctorService.Add(
            new Doctor(Guid.Empty, "1", new Specialization(Guid.Empty, "1")));
        
        Assert.True(res.IsFailure);
        Assert.Equal("Cannot add a doctor", res.Error);
    }

    [Fact]
    public void DoctorDeleteById_ShouldFail()
    {
        _doctorRepositoryMock.Setup(repository =>
            repository.DeleteDoctor(It.IsAny<Guid>()))
            .Returns(false);
        
        _doctorRepositoryMock.Setup(repository =>
                repository.IsDoctorExists(It.IsAny<Guid>()))
            .Returns(() => true);

        var res = _doctorService.DeleteById(Guid.Empty);
        
        Assert.True(res.IsFailure);
        Assert.Equal("Cannot delete a doctor", res.Error);
    }

    [Fact]
    public void DoctorGetAll()
    {
        _doctorRepositoryMock.Setup(repository =>
            repository.GetDoctors())
            .Returns(() => new List<Doctor>());
        
        var res = _doctorService.GetAll();
        
        Assert.True(res.Success);
    }

    [Fact]
    public void DoctorGetById_ShouldFail()
    {
        _doctorRepositoryMock.Setup(repository =>
                repository.GetDoctorById(It.IsAny<Guid>()))
            .Returns(() => 
                new Doctor(Guid.Empty, "", new Specialization(Guid.Empty, "")));

        _doctorRepositoryMock.Setup(repository =>
                repository.IsDoctorExists(It.IsAny<Guid>()))
            .Returns(() => true);

        var res = _doctorService.GetById(Guid.Empty);
        
        Assert.True(res.IsFailure);
        Assert.Equal("Cannot get a doctor by id", res.Error);
    }
}