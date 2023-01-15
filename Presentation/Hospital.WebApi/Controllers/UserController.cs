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
    
    [HttpGet("user")]
    public ActionResult<UserSearchView> GetUserByLogin(string login)
    {
        if (login == string.Empty)
            return Problem(statusCode: 404, detail: "login not specified");

        var userRes = _service.FindByLogin(login);
        if (userRes.IsFailure)
            return Problem(statusCode: 404, detail: userRes.Error);

        return Ok(new UserSearchView
        {
            Id = userRes.Value.Id,
            PhoneNumber = userRes.Value.PhoneNumber,
            Name = userRes.Value.Name,
            Role = userRes.Value.Role
        });
    }
}