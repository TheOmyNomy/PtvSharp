using Newtonsoft.Json;

namespace PtvSharp.Models;

public class RouteServiceStatus
{
	[JsonProperty("description")]
	public string? Description { get; set; }

	[JsonProperty("timestamp")]
	public string? Timestamp { get; set; }
}