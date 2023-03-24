using Newtonsoft.Json;

namespace PtvSharp.Models;

public class VehicleDescriptor
{
	[JsonProperty("operator")]
	public string? Operator { get; set; }

	[JsonProperty("id")]
	public string? Id { get; set; }

	[JsonProperty("low_floor")]
	public bool? LowFloor { get; set; }

	[JsonProperty("air_conditioned")]
	public bool? AirConditioned { get; set; }

	[JsonProperty("description")]
	public string? Description { get; set; }

	[JsonProperty("supplier")]
	public string? Supplier { get; set; }

	[JsonProperty("length")]
	public string? Length { get; set; }
}