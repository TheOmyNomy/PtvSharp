using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopsOnRouteResponse : Response
{
	[JsonProperty("stops")]
	public StopOnRoute[]? Stops { get; set; }

	[JsonProperty("disruptions")]
	public object? Disruptions { get; set; }

	[JsonProperty("geopath")]
	public object[]? Geopath { get; set; }
}