using Hospital.Domain;
using Hospital.Persistence.Validations;
using Xunit;

namespace Test.DoctorTests;

public class SpecializationValidationTests
{
    private Specialization _specializationEmpty;

    public SpecializationValidationTests()
    {
        _specializationEmpty = new Specialization("");
    }

    [Fact]
    public void SpecializationIsEmpty_ShouldFail()
    {
        var res = SpecializationValidation.IsValid(_specializationEmpty);
        
        Assert.True(res.IsFailure);
        Assert.Equal("Specialization name error", res.Error);
    }
}