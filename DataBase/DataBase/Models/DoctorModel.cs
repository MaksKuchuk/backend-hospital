using Hospital.Domain;

namespace DataBase.Models;

public class DoctorModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public Specialization Specialization { get; set; }
}