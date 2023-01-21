using Hospital.Domain;
using Hospital.Persistence.UseCases;
using Hospital.WebApi.Views;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly UserService _service;
    public UserController(UserService service)
    {
        _service = service;
    }
    
    [HttpGet("isexists")]
    public ActionResult<UserSearchView> IsExists(string login)
    {
        
        var res = _service.IsExists(login);
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);
        
        return Ok(res.Value);
    }
    
    [HttpPost("registeruser")]
    public ActionResult<UserSearchView> RegisterUser(string phone, string name, Role role)
    {
        User user = new User(Guid.Empty, phone, name, role);
        var res = _service.Register(user);

        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Value);
    }
    
    [HttpGet("findbylogin")]
    public ActionResult<UserSearchView> FindByLogin(string login)
    {
        if (login == string.Empty)
            return Problem(statusCode: 412, detail: "login not specified");

        var userRes = _service.FindByLogin(login);
        if (userRes.IsFailure)
            return Problem(statusCode: 500, detail: userRes.Error);

        return Ok(new UserSearchView
        {
            Id = userRes.Value.Id,
            PhoneNumber = userRes.Value.PhoneNumber,
            Name = userRes.Value.Name,
            Role = userRes.Value.Role
        });
    }
}