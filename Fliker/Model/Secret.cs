namespace Fliker
{
	/// <summary>
	/// Secret.
	/// </summary>
	public class Secret
	{
		public const string SECRET_CACHE_KEY = "secret";

		/// <summary>
		/// Gets the token.
		/// </summary>
		/// <value>The token.</value>
		public string Token { get; private set; }

		/// <summary>
		/// Gets the network.
		/// </summary>
		/// <value>The network.</value>
		public AuthType Network { get; private set; }

		/// <summary>
		/// Gets the client identifier.
		/// </summary>
		/// <value>The client identifier.</value>
		public string ClientId { get; private set;}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Fliker.Secret"/> class.
		/// </summary>
		/// <param name="token">Token.</param>
		/// <param name="clientId">Client identifier.</param>
		/// <param name="network">Network.</param>
		public Secret(string token, string clientId, AuthType network)
		{
			Token = token;
			Network = network;
			ClientId = clientId;
		}
	}
}
