namespace Hospital.Domain;

public class Appointment
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
}