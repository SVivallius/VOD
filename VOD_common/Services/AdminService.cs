using System;
using System.Text.Json;
using VOD.common.HttpClients;

namespace VOD.common.Services;

public class AdminService : IAdminService
{
	private readonly MembershipHttpClient _http;
	public AdminService(MembershipHttpClient client)
	{
		_http = client;
	}

	public async Task<List<TDto>> GetAsync<TDto>(string uri)
	{
		try
		{
			using HttpResponseMessage response = await _http._client.GetAsync(uri);

			response.EnsureSuccessStatusCode();

			var returnValue = JsonSerializer.Deserialize<List<TDto>>(
				await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

			if (returnValue != null) return new List<TDto>();
			return returnValue;
		}
		catch (Exception)
		{
			throw;
		}
	}
}
