using Hospital.Domain;
using Hospital.Persistence.UseCases;
using Hospital.WebApi.Views;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers;

[ApiController]
[Route("doctor")]
public class DoctorController : ControllerBase
{
    private readonly DoctorService _service;
    public DoctorController(DoctorService service)
    {
        _service = service;
    }

    [HttpPost("add")]
    public ActionResult<DoctorSearchView> Add(string name, Specialization specialization)
    {
        Doctor doc = new Doctor(Guid.Empty, name, specialization);
        var res = _service.Add(doc);
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Value);
    }
    
    [HttpGet("isexists")]
    public ActionResult<AppointmentSearchView> IsExists(Guid id)
    {
        var res = _service.IsExists(id);
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Value);
    }
    
    [HttpGet("deletebyid")]
    public ActionResult<AppointmentSearchView> DeleteById(Guid id)
    {
        var res = _service.DeleteById(id);
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Value);
    }
    
    [HttpGet("getall")]
    public ActionResult<AppointmentSearchView> GetAll()
    {
        var res = _service.GetAll();
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Value);
    }
    
    [HttpGet("getbyid")]
    public ActionResult<AppointmentSearchView> GetById(Guid id)
    {
        var res = _service.GetById(id);
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Value);
    }
}