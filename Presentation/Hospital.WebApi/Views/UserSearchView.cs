using System.Text.Json.Serialization;
using Hospital.Domain;

namespace Hospital.WebApi.Views;

public class UserSearchView
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }
    [JsonPropertyName("PhoneNumber")]
    public string PhoneNumber { get; set; }
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    [JsonPropertyName("Role")]
    public Role Role { get; set; }
}