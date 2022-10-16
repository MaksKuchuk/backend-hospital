using System;
using Hospital.Domain;
using Hospital.Persistence.Interfaces;
using Hospital.Persistence.UseCases;
using Moq;
using Xunit;

namespace Test.UserTests;

public class UserServiceTests
{
    private readonly UserService _userService;
    private readonly Mock<IUserRepository> _userRepositoryMock;

    public UserServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object);
    }

    [Fact]
    public void UserIsExists_EmptyLogin_ShouldFail()
    {
        var res= _userService.IsExists(string.Empty);
        
        Assert.True(res.IsFailure);
        Assert.Equal("Login input error", res.Error);
    }
    
    [Fact]
    public void UserIsExists_NonExistentLogin_ShouldFail()
    {
        var res= _userService.IsExists("123");
        
        Assert.False(res.IsFailure);
        Assert.False(res.Value);
    }

    [Fact]
    public void UserRegister_EmptyUser_ShouldFail()
    {
        var res = _userService.Register(
            new User(Guid.NewGuid(), "", "", Role.Admin));

        Assert.True(res.IsFailure);
        Assert.Equal("Invalid user form", res.Error);
    }
    
    [Fact]
    public void UserRegister_CannotRegister_ShouldFail()
    {
        _userRepositoryMock.Setup(repository => 
                repository.CreateUser(It.IsAny<User>()))
            .Returns(() => false);

        var res = _userService.Register(
            new User(Guid.Empty, "1", "1", Role.Admin));
        
        Assert.True(res.IsFailure);
        Assert.Equal("Cannot create user", res.Error);
    }

    [Fact]
    public void FindByLogin_EmptyLogin_ShouldFail()
    {
        var res = _userService.FindByLogin("");
        
        Assert.True(res.IsFailure);
        Assert.Equal("Login input error", res.Error);
    }
    
    [Fact]
    public void FindByLogin_NonExistentLogin_ShouldFail()
    {
        _userRepositoryMock.Setup(repository => 
                repository.IsUserExists(It.IsAny<string>()))
            .Returns(() => false);

        var res = _userService.FindByLogin("123");
        
        Assert.True(res.IsFailure);
        Assert.Equal("User doesn't exist", res.Error);
    }
}