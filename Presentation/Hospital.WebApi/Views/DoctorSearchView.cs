using System.Text.Json.Serialization;
using Hospital.Domain;

namespace Hospital.WebApi.Views;

public class DoctorSearchView
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    [JsonPropertyName("Specialization")]
    public Specialization Specialization { get; set; }
}