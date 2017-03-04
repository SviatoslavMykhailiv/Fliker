using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Fliker
{
	/// <summary>
	/// Connection dispatcher. Singleton instance;
	/// </summary>
	public abstract class RequestDispatcherBase
	{
		/// <summary>
		/// The name of the hub.
		/// </summary>
		private const string HubName = "Connector";

		/// <summary>
		/// The connection.
		/// </summary>
		protected HubConnection connection;

		/// <summary>
		/// The hub proxy.
		/// </summary>
		protected IHubProxy hubProxy;

		/// <summary>
		/// Connects the server by user id
		/// </summary>
		/// <param name="userId">User identifier.</param>
		protected async Task Connect(string userId, AuthType authType)
		{
			try
			{
				await connection.Start();
				await Invoke(ConectivityConstants.Connect, userId, authType);
			}
			catch
			{
				throw new ConnectionException("Couldn't connect to server");
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Fliker.ConnectionDispatcher"/> class.
		/// </summary>
		protected RequestDispatcherBase()
		{
			try
			{
				connection = new HubConnection(ConectivityConstants.ServiceBaseUrl);
				hubProxy = connection.CreateHubProxy(HubName);
			}
			catch
			{
				throw new ConnectionException("Couldn't create connection to server");
			}
		}

		/// <summary>
		/// Invokes the inner.
		/// </summary>
		/// <returns>The inner.</returns>
		/// <param name="serverMethodName">Server method name.</param>
		/// <param name="parameters">Parameters.</param>
		private async Task InvokeInner(string serverMethodName, params object[] parameters)
		{
			if (connection.State == ConnectionState.Connected)
			{
				await hubProxy.Invoke(serverMethodName, parameters);
			}
			else
			{
				throw new ConnectionException("You have been disconnected");
			}
		}

		protected async Task Invoke(string methodName, params object[] parameters)
		{
			await InvokeInner(methodName, parameters);
		}

		protected void On<TModel>(string broadcastMethod, Action<TModel> callback)
		{
			hubProxy.On(broadcastMethod, callback);
		}

		protected void On(string broadcastMethod, Action callback)
		{
			hubProxy.On(broadcastMethod, callback);
		}
	}
}
