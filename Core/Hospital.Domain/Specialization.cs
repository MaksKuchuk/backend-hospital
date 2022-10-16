namespace Hospital.Domain;

public class Specialization
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Specialization(string name)
    {
        Name = name;
    }
}