namespace Hospital.Domain;

public class Doctor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Specialization Specialization { get; set; }

    public Doctor(Guid guid, string name, Specialization specialization)
    {
        Id = guid;
        Name = name;
        Specialization = specialization;
    }
}