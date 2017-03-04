namespace Fliker
{
	/// <summary>
	/// APIF actory.
	/// </summary>
	public static class APIFactory
	{
		/// <summary>
		/// Create the specified type.
		/// </summary>
		/// <param name="type">Type.</param>
		public static IAPIProvider Create(AuthType type)
		{
			switch (type)
			{
				case AuthType.FB:
					return new FBApiService();
				case AuthType.VK:
					return new VKAPIService();
			}

			return null;
		}
	}
}
