using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopGps
{
	[JsonProperty("latitude")]
	public float? Latitude { get; set; }

	[JsonProperty("longitude")]
	public float? Longitude { get; set; }
}