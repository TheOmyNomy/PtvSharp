using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopDetails
{
	[JsonProperty("disruptions_ids")]
	public int[]? DisruptionIds { get; set; }

	[JsonProperty("station_type")]
	public string? StationType { get; set; }

	[JsonProperty("station_description")]
	public string? StationDescription { get; set; }

	[JsonProperty("route_type")]
	public int? RouteType { get; set; }

	[JsonProperty("stop_location")]
	public StopLocation? Location { get; set; }

	[JsonProperty("stop_amenities")]
	public StopAmenityDetails? Amenities { get; set; }

	[JsonProperty("stop_accessibility")]
	public StopAccessibility? Accessibility { get; set; }

	[JsonProperty("stop_staffing")]
	public StopStaffing? Staffing { get; set; }

	[JsonProperty("routes")]
	public object[]? Routes { get; set; }

	[JsonProperty("stop_id")]
	public int? Id { get; set; }

	[JsonProperty("stop_name")]
	public string? Name { get; set; }

	[JsonProperty("stop_landmark")]
	public string? Landmark { get; set; }
}