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

	public async Task<SearchResponse?> GetSearchAsync(string term)
	{
		string endpoint = ConstructEndpoint(SearchEndpoint, term);
		string url = ConstructUrl(endpoint);

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

	private string ConstructUrl(string endpoint, Dictionary<string, string>? parameters = null)
	{
		StringBuilder urlBuilder = new StringBuilder(endpoint);
		urlBuilder.Append("?devid=").Append(_developerId);

		if (parameters != null)
		{
			foreach (var parameter in parameters)
			{
				urlBuilder.Append("&").Append(parameter.Key).Append("=");

				if (!string.IsNullOrWhiteSpace(parameter.Value))
				{
					string value = Uri.EscapeDataString(parameter.Value);
					urlBuilder.Append(value);
				}
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