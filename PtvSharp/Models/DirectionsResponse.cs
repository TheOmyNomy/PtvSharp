using Newtonsoft.Json;

namespace PtvSharp.Models;

public class DirectionsResponse : Response
{
	[JsonProperty("directions")]
	public Direction[]? Directions { get; set; }
}