namespace Backend.Interview.Api.Models;

public class Person
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("firstName")]
    public string FirstName { get; set; }
    [JsonProperty("lastName")]
    public string LastName { get; set; }
    [JsonProperty("dob")]
    public DateTime? Dob { get; set; }
    [JsonProperty("address")]
    public Address? Address { get; set; }
}
