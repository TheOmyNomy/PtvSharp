using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using PtvSharp.Models;

namespace PtvSharp;

public class PtvClient
{
	private const string BaseUrl = "https://timetableapi.ptv.vic.gov.au";

	private const string VersionEndpoint = "/v3";
	private const string RouteTypesEndpoint = VersionEndpoint + "/route_types";
	private const string SearchEndpoint = VersionEndpoint + "/search/{0}";

	private static readonly HttpClient Client = new()
	{
		BaseAddress = new Uri(BaseUrl)
	};

	private readonly int _developerId;
	private readonly string _developerKey;

	public PtvClient(int developerId, string developerKey)
	{
		_developerId = developerId;
		_developerKey = developerKey;
	}

	public async Task<RouteTypesResponse?> GetRouteTypesAsync()
	{
		string endpoint = ConstructEndpoint(RouteTypesEndpoint);
		string url = ConstructUrl(endpoint);

		return await GetAsync<RouteTypesResponse>(url);
	}

	public async Task<SearchResponse?> GetSearchAsync(string term, int[]? routeTypes = null, float? latitude = null, float? longitude = null, float? maxDistance = null,
		bool? includeOutlets = null, bool? matchStopBySuburb = null, bool? matchRouteBySuburb = null, bool? matchStopByGtfsStopId = null)
	{
		string endpoint = ConstructEndpoint(SearchEndpoint, term);

		List<Parameter> parameters = new List<Parameter>();

		if (routeTypes != null)
		{
			foreach (int routeType in routeTypes)
				parameters.Add(Parameter.Create("route_types", routeType));
		}

		if (latitude.HasValue)
			parameters.Add(Parameter.Create("latitude", latitude.Value));

		if (longitude.HasValue)
			parameters.Add(Parameter.Create("longitude", longitude.Value));

		if (maxDistance.HasValue)
			parameters.Add(Parameter.Create("max_distance", maxDistance.Value));

		if (includeOutlets.HasValue)
			parameters.Add(Parameter.Create("include_outlets", includeOutlets.Value));

		if (matchStopBySuburb.HasValue)
			parameters.Add(Parameter.Create("match_stop_by_suburb", matchStopBySuburb.Value));

		if (matchRouteBySuburb.HasValue)
			parameters.Add(Parameter.Create("match_route_by_suburb", matchRouteBySuburb.Value));

		if (matchStopByGtfsStopId.HasValue)
			parameters.Add(Parameter.Create("match_stop_by_gtfs_stop_id", matchStopByGtfsStopId.Value));

		string url = ConstructUrl(endpoint, parameters);

		return await GetAsync<SearchResponse>(url);
	}

	private async Task<T?> GetAsync<T>(string url) where T : Response
	{
		using HttpResponseMessage responseMessage = await Client.GetAsync(url);
		string contents = await responseMessage.Content.ReadAsStringAsync();

		return JsonConvert.DeserializeObject<T>(contents);
	}

	private string ConstructEndpoint(string endpoint, params object[] arguments)
	{
		for (int i = 0; i < arguments.Length; i++)
		{
			if (arguments[i] is string value && !string.IsNullOrWhiteSpace(value))
				arguments[i] = Uri.EscapeDataString(value);
		}

		return string.Format(endpoint, arguments);
	}

	private string ConstructUrl(string endpoint, List<Parameter>? parameters = null)
	{
		StringBuilder urlBuilder = new StringBuilder(endpoint);
		urlBuilder.Append("?devid=").Append(_developerId);

		if (parameters != null)
		{
			foreach (var parameter in parameters)
			{
				urlBuilder.Append("&").Append(parameter.Name).Append("=");

				string value = Uri.EscapeDataString(parameter.Value.ToString()!);
				urlBuilder.Append(value);
			}
		}

		byte[] keyBytes = Encoding.ASCII.GetBytes(_developerKey);

		string url = urlBuilder.ToString();
		byte[] urlBytes = Encoding.ASCII.GetBytes(url);

		byte[] tokenBytes = new HMACSHA1(keyBytes).ComputeHash(urlBytes);

		StringBuilder signatureBuilder = new StringBuilder();

		Array.ForEach(tokenBytes, tokenByte =>
		{
			string value = tokenByte.ToString("X2");
			signatureBuilder.Append(value);
		});

		string signature = signatureBuilder.ToString();
		urlBuilder.Append("&signature=").Append(signature);

		return urlBuilder.ToString();
	}
}