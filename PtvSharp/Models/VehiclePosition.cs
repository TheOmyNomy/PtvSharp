using Newtonsoft.Json;

namespace PtvSharp.Models;

public class VehiclePosition
{
	[JsonProperty("latitude")]
	public float? Latitude { get; set; }

	[JsonProperty("longitude")]
	public float? Longitude { get; set; }

	[JsonProperty("easting")]
	public float? Easting { get; set; }

	[JsonProperty("northing")]
	public float? Northing { get; set; }

	[JsonProperty("direction")]
	public string? Direction { get; set; }

	[JsonProperty("bearing")]
	public float? Bearing { get; set; }

	[JsonProperty("supplier")]
	public string? Supplier { get; set; }

	[JsonProperty("datetime_utc")]
	public string? DateTimeUtc { get; set; }

	[JsonProperty("expiry_time")]
	public string? ExpiryTime { get; set; }
}