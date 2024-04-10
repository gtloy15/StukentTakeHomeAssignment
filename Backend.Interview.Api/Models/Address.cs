namespace Backend.Interview.Api.Models;

public class Address
{
    [JsonProperty("line1")]
    public string Line1 { get; set; }
    [JsonProperty("line2")]
    public string? Line2 { get; set; }
    [JsonProperty("city")]
    public string City { get; set; }
    [JsonProperty("state")]
    public string State { get; set; }
    [JsonProperty("zipCode")]
    public string ZipCode { get; set; }
}
