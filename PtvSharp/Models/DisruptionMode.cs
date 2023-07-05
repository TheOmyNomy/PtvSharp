using Newtonsoft.Json;

namespace PtvSharp.Models;

public class DisruptionMode
{
	[JsonProperty("disruption_mode_name")]
	public string? Name { get; set; }

	[JsonProperty("disruption_mode")]
	public int? Id { get; set; }
}