using Newtonsoft.Json;

namespace PtvSharp.Models;

public class Status
{
	[JsonProperty("version")]
	public string? Version { get; set; }

	[JsonProperty("health")]
	public int? Health { get; set; }
}