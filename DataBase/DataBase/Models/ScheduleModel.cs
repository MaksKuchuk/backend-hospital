namespace DataBase.Models;

public class ScheduleModel
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime DayStart { get; set; }
    public DateTime DayEnd { get; set; }
}