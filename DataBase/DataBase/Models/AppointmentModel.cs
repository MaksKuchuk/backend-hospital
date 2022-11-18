namespace DataBase.Models;

public class AppointmentModel
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
}