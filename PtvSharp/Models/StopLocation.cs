using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopLocation
{
	[JsonProperty("gps")]
	public StopGps? Gps { get; set; }
}