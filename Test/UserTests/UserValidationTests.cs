using System;
using Hospital.Domain;
using Hospital.Persistence.Validations;
using Xunit;

namespace Test.UserTests;

public class UserValidationTests
{
    private User _emptyUser;
    private User _phoneNumberUser;
    private User _nameUser;
    
    public UserValidationTests()
    {
        _emptyUser = new User(Guid.NewGuid(), "", "", Role.Admin, "");
        
        _phoneNumberUser = 
            new User(Guid.NewGuid(), "", "username", Role.Admin, "");
        
        _nameUser = new User(Guid.NewGuid(), "+81234567890", "", Role.Admin, "");
    }
    
    [Fact]
    public void UserIsEmpty_ShouldFail()
    {
        var check = UserValidation.IsValid(_emptyUser);
        
        Assert.True(check.IsFailure);
    }
    
    [Fact]
    public void PhoneNumberIsEmpty_ShouldFail()
    {
        var check = UserValidation.IsValid(_phoneNumberUser);
        
        Assert.True(check.IsFailure);
        Assert.Equal("Phone number error", check.Error);
    }
    
    [Fact]
    public void NameIsEmpty_ShouldFail()
    {
        var check = UserValidation.IsValid(_nameUser);
        
        Assert.True(check.IsFailure);
        Assert.Equal("Name error", check.Error);
    }
}