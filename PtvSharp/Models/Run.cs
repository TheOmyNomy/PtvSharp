using Newtonsoft.Json;

namespace PtvSharp.Models;

public class Run
{
	[JsonProperty("run_id")]
	public int? Id { get; set; }

	[JsonProperty("run_ref")]
	public string? Ref { get; set; }

	[JsonProperty("route_id")]
	public int? RouteId { get; set; }

	[JsonProperty("route_type")]
	public int? RouteType { get; set; }

	[JsonProperty("final_stop_id")]
	public int? FinalStopId { get; set; }

	[JsonProperty("destination_name")]
	public string? DestinationName { get; set; }

	[JsonProperty("status")]
	public string? Status { get; set; }

	[JsonProperty("direction_id")]
	public int? DirectionId { get; set; }

	[JsonProperty("run_sequence")]
	public int? Sequence { get; set; }

	[JsonProperty("express_stop_count")]
	public int? ExpressStopCount { get; set; }

	[JsonProperty("vehicle_position")]
	public VehiclePosition? VehiclePosition { get; set; }

	[JsonProperty("vehicle_descriptor")]
	public VehicleDescriptor? VehicleDescriptor { get; set; }

	[JsonProperty("geopath")]
	public object[]? Geopath { get; set; }
}