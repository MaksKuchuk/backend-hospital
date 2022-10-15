namespace Hospital.Domain;

public class Schedule
{
    public Guid DoctorId { get; set; }
    public DateTime DayStart { get; set; }
    public DateTime DayEnd { get; set; }
}