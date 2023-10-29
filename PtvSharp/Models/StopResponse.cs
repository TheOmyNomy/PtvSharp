using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopResponse : Response
{
	[JsonProperty("stop")]
	public StopDetails? StopDetails { get; set; }

	[JsonProperty("disruptions")]
	public object? Disruptions { get; set; }
}