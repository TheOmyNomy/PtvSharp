using Newtonsoft.Json;

namespace PtvSharp.Models;

public class SearchResponse
{
	[JsonProperty("stops")]
	public Stop[]? Stops { get; set; }

	[JsonProperty("routes")]
	public Route[]? Routes { get; set; }

	[JsonProperty("outlets")]
	public Outlet[]? Outlets { get; set; }

	[JsonProperty("status")]
	public Status? Status { get; set; }
}