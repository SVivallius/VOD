using System.Text.Json;

namespace VOD.common.HttpClients;

public class MembershipHttpClient
{
	public HttpClient _client;

	public MembershipHttpClient(HttpClient client)
	{
		_client = client;
	}
}
