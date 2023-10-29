using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopOnRoute
{
	[JsonProperty("disruption_ids")]
	public int[]? disruptionIds { get; set; }

	[JsonProperty("stop_suburb")]
	public string? Suburb { get; set; }

	[JsonProperty("route_type")]
	public int? RouteType { get; set; }

	[JsonProperty("stop_latitude")]
	public float? Latitude { get; set; }

	[JsonProperty("stop_longitude")]
	public float? Longitude { get; set; }

	[JsonProperty("stop_sequence")]
	public int? Sequence { get; set; }

	[JsonProperty("stop_ticket")]
	public StopTicket? Ticket { get; set; }

	[JsonProperty("stop_id")]
	public int? Id { get; set; }

	[JsonProperty("stop_name")]
	public string? Name { get; set; }

	[JsonProperty("stop_landmark")]
	public string? Landmark { get; set; }
}