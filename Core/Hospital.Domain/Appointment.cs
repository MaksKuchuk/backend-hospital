namespace Hospital.Domain;

public class Appointment
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }

    public Appointment(Guid id, Guid doctorId, Guid patientId, DateTime startTime, DateTime endTime)
    {
        Id = id;
        StartTime = startTime;
        EndTime = endTime;
        DoctorId = doctorId;
        PatientId = patientId;
    }
}