using System;

namespace Fliker
{
	/// <summary>
	/// Connection exception.
	/// </summary>
	public class ConnectionException : Exception
	{
		public ConnectionException(string message) : base(message)
		{
		}
	}
}
