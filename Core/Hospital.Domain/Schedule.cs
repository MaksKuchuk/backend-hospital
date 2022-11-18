namespace Hospital.Domain;

public class Schedule
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime DayStart { get; set; }
    public DateTime DayEnd { get; set; }

    public Schedule(Guid id, Guid doctorId, DateTime dayStart, DateTime dayEnd)
    {
        Id = id;
        DoctorId = doctorId;
        DayStart = dayStart;
        DayEnd = dayEnd;
    }
}