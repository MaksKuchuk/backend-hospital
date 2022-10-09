namespace Hospital.Domain;

public class Doctor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Specialization Specialization { get; set; }
}