using Newtonsoft.Json;

namespace PtvSharp.Models;

public class SearchResponse : Response
{
	[JsonProperty("stops")]
	public Stop[]? Stops { get; set; }

	[JsonProperty("routes")]
	public Route[]? Routes { get; set; }

	[JsonProperty("outlets")]
	public Outlet[]? Outlets { get; set; }
}