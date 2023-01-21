using System.Text.Json.Serialization;

namespace Hospital.WebApi.Views;

public class ScheduleSearchView
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }
    [JsonPropertyName("DoctorId")]
    public Guid DoctorId { get; set; }
    [JsonPropertyName("DayStart")]
    public DateTime DayStart { get; set; }
    [JsonPropertyName("DayEnd")]
    public DateTime DayEnd { get; set; }
}