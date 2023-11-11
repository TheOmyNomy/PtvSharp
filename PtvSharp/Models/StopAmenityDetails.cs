using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopAmenityDetails
{
	[JsonProperty("toilet")]
	public bool? Toilet { get; set; }

	[JsonProperty("taxi_rank")]
	public bool? TaxiRank { get; set; }

	[JsonProperty("car_parking")]
	public string? CarParking { get; set; }

	[JsonProperty("cctv")]
	public bool? Cctv { get; set; }
}