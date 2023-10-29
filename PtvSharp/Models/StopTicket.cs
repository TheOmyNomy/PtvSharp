using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopTicket
{
	[JsonProperty("ticket_type")]
	public string? Type { get; set; }

	[JsonProperty("zone")]
	public string? Zone { get; set; }

	[JsonProperty("is_free_fare_zone")]
	public bool? IsFreeFareZone { get; set; }

	[JsonProperty("ticket_machine")]
	public bool? Machine { get; set; }

	[JsonProperty("ticket_checks")]
	public bool? Checks { get; set; }

	[JsonProperty("vline_reservation")]
	public bool? VLineReservation { get; set; }

	[JsonProperty("ticket_zones")]
	public int[]? Zones { get; set; }
}