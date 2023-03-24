using Newtonsoft.Json;

namespace PtvSharp.Models;

public class RoutesResponse : Response
{
	[JsonProperty("routes")]
	public Route[]? Routes { get; set; }
}