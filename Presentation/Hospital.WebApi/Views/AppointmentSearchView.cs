using System.Text.Json.Serialization;

namespace Hospital.WebApi.Views;

public class AppointmentSearchView
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }
    [JsonPropertyName("StartTime")]
    public DateTime StartTime { get; set; }
    [JsonPropertyName("EndTime")]
    public DateTime EndTime { get; set; }
    [JsonPropertyName("PatientId")]
    public Guid PatientId { get; set; }
    [JsonPropertyName("DoctorId")]
    public Guid DoctorId { get; set; }
}