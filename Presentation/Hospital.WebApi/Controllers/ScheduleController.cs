using Hospital.Domain;
using Hospital.Persistence.UseCases;
using Hospital.WebApi.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers;

[ApiController]
[Route("schedule")]
public class ScheduleController : ControllerBase
{
    private readonly ScheduleService _service;
    public ScheduleController(ScheduleService service)
    {
        _service = service;
    }
    
    [Authorize]
    [HttpPost("getschedule")]
    public ActionResult<ScheduleSearchView> GetSchedule(Guid id, DateTime time)
    {
        var res = _service.GetSchedule(id, time);
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Value);
    }
    
    [Authorize]
    [HttpPost("addschedule")]
    public ActionResult<ScheduleSearchView> AddSchedule(Guid id, Guid doctorId, DateTime dayStart, DateTime dayEnd)
    {
        Schedule sch = new Schedule(Guid.Empty, doctorId, dayStart, dayEnd);
        var res = _service.AddSchedule(id, sch);
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Success);
    }
    
    [Authorize]
    [HttpPost("updateschedule")]
    public ActionResult<ScheduleSearchView> UpdateSchedule(Guid id, Guid doctorId, DateTime dayStart, DateTime dayEnd)
    {
        Schedule sch = new Schedule(Guid.Empty, doctorId, dayStart, dayEnd);
        var res = _service.UpdateSchedule(id, sch);
        
        if (res.IsFailure)
            return Problem(statusCode: 500, detail: res.Error);

        return Ok(res.Success);
    }
}