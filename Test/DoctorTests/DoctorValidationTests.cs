using System;
using Hospital.Domain;
using Hospital.Persistence.Validations;
using Xunit;

namespace Test.DoctorTests;

public class DoctorValidationTests
{
    private Doctor _emptyDoctor;
    private Doctor _nameDoctor;
    private Doctor _specializationDoctor;

    public DoctorValidationTests()
    {
        _emptyDoctor = new Doctor(Guid.NewGuid(), "", new Specialization(Guid.Empty, ""));
        _nameDoctor = new Doctor(Guid.NewGuid(), "", new Specialization(Guid.Empty, "any"));
        _specializationDoctor = 
            new Doctor(Guid.NewGuid(), "any", new Specialization(Guid.Empty, ""));
    }

    [Fact]
    public void DoctorIsEmpty_ShouldFail()
    {
        var res = DoctorValidation.IsValid(_emptyDoctor);

        Assert.True(res.IsFailure);
    }
    
    [Fact]
    public void NameDoctorIsEmpty_ShouldFail()
    {
        var res = DoctorValidation.IsValid(_nameDoctor);

        Assert.True(res.IsFailure);
        Assert.Equal("Name error", res.Error);
    }
    
    [Fact]
    public void SpecializationDoctorIsEmpty_ShouldFail()
    {
        var res = DoctorValidation.IsValid(_specializationDoctor);

        Assert.True(res.IsFailure);
        Assert.Equal("Specialization name error", res.Error);
    }
}