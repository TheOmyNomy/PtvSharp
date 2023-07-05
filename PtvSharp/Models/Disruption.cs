using Newtonsoft.Json;

namespace PtvSharp.Models;

public class Disruption
{
	[JsonProperty("disruption_id")]
	public int? Id { get; set; }

	[JsonProperty("title")]
	public string? Title { get; set; }

	[JsonProperty("url")]
	public string? Url { get; set; }

	[JsonProperty("description")]
	public string? Description { get; set; }

	[JsonProperty("disruption_status")]
	public string? Status { get; set; }

	[JsonProperty("disruption_type")]
	public string? Type { get; set; }

	[JsonProperty("published_on")]
	public string? PublishedOn { get; set; }

	[JsonProperty("last_updated")]
	public string? LastUpdated { get; set; }

	[JsonProperty("from_date")]
	public string? FromDate { get; set; }

	[JsonProperty("to_date")]
	public string? ToDate { get; set; }

	[JsonProperty("routes")]
	public DisruptionRoute[]? Routes { get; set; }

	[JsonProperty("stops")]
	public DisruptionStop[]? Stops { get; set; }

	[JsonProperty("colour")]
	public string? Colour { get; set; }

	[JsonProperty("display_on_board")]
	public bool? DisplayOnBoard { get; set; }

	[JsonProperty("display_status")]
	public bool? DisplayStatus { get; set; }
}