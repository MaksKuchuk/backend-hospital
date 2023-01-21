using Hospital.Domain;
using Hospital.Persistence.UseCases;
using Hospital.WebApi.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers;

[ApiController]
[Route("appointment")]
public class AppointmentController : ControllerBase
{
    private readonly AppointmentService _service;
    public AppointmentController(AppointmentService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpPost("addtodoctor")]
    public ActionResult<AppointmentSearchView> AddToDoctor(Guid doctorId, Guid patientId, DateTime startTime, DateTime endTime)
    {
        Appointment appo = new Appointment(Guid.Empty, doctorId, patientId, startTime, endTime);
        var res = _service.AddToDoctor(appo);
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Success);
    }

    [Authorize]
    [HttpPost("addtofreedoctor")]
    public ActionResult<AppointmentSearchView> AddToFreeDoctor(Guid id, string name)
    {
        Specialization spec = new Specialization(id, name);
        var res = _service.AddToFreeDoctor(spec);
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Value);
    }

    [Authorize]
    [HttpPost("getallfree")]
    public ActionResult<AppointmentSearchView> GetAllFree(Guid id, string name)
    {
        Specialization spec = new Specialization(id, name);
        var res = _service.GetAllFree(spec);
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Value);
    }
}