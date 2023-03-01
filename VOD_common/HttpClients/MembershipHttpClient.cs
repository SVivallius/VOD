namespace VOD.common.HttpClients;

public class MembershipHttpClient
{
	HttpClient _client;

	public MembershipHttpClient(HttpClient client)
	{
		_client = client;
	}
}
