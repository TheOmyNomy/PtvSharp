using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopsByDistanceResponse : Response
{
	[JsonProperty("stops")]
	public StopGeosearch[]? Stops { get; set; }

	[JsonProperty("disruptions")]
	public object? Disruptions { get; set; }
}