using Newtonsoft.Json;

namespace PtvSharp.Models;

public class Departure
{
	[JsonProperty("stop_id")]
	public int? StopId { get; set; }

	[JsonProperty("route_id")]
	public int? RouteId { get; set; }

	[JsonProperty("run_id")]
	public int? RunId { get; set; }

	[JsonProperty("run_ref")]
	public string? RunRef { get; set; }

	[JsonProperty("direction_id")]
	public int? DirectionId { get; set; }

	[JsonProperty("disruption_ids")]
	public int[]? DisruptionIds { get; set; }

	[JsonProperty("scheduled_departure_utc")]
	public string? ScheduledDepartureUtc { get; set; }

	[JsonProperty("estimated_departure_utc")]
	public string? EstimatedDepartureUtc { get; set; }

	[JsonProperty("at_platform")]
	public bool? AtPlatform { get; set; }

	[JsonProperty("platform_number")]
	public string? PlatformNumber { get; set; }

	[JsonProperty("flags")]
	public string? Flags { get; set; }

	[JsonProperty("departure_sequence")]
	public int? DepartureSequence { get; set; }
}