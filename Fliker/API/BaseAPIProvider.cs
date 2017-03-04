using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fliker
{
	/// <summary>
	/// Base APIP rovider.
	/// </summary>
	public abstract class BaseAPIProvider : IDisposable, IAPIProvider
	{
		HttpClient _http;

		protected BaseAPIProvider()
		{
			_http = new HttpClient();
		}

		public abstract Task Like(string itemId);
		public abstract Task<IUser> GetUser(string id = null);
		protected abstract string BaseAPIURL { get; }

		/// <summary>
		/// Gets as string.
		/// </summary>
		/// <returns>The as string.</returns>
		/// <param name="requestURI">Request URI.</param>
		protected virtual async Task<string> GetAsString(string requestURI)
		{
			try
			{
				var request = await _http.GetAsync(requestURI);
				return await request.Content.ReadAsStringAsync();
			}
			catch
			{
				throw new ConnectionException("Connection error");
			}
		}

		/// <summary>
		/// Gets as bytes.
		/// </summary>
		/// <returns>The as bytes.</returns>
		/// <param name="requestURI">Request URI.</param>
		protected virtual async Task<byte[]> GetAsBytes(string requestURI)
		{
			try
			{
				var request = await _http.GetAsync(requestURI);
				return await request.Content.ReadAsByteArrayAsync();
			}
			catch
			{
				throw new ConnectionException("Connection error");
			}
		}

		/// <summary>
		/// Post the specified url and parameters.
		/// </summary>
		/// <param name="url">URL.</param>
		/// <param name="parameters">Parameters.</param>
		protected virtual async Task<string> Post(string url, Dictionary<string, string> parameters)
		{
			try
			{
				var request = await _http.PostAsync(url, new FormUrlEncodedContent(parameters));
				return await request.Content.ReadAsStringAsync();
			}
			catch
			{
				throw new ConnectionException("Connection error");
			}
		}

		/// <summary>
		/// Releases all resource used by the <see cref="T:Fliker.BaseAPIProvider"/> object.
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:Fliker.BaseAPIProvider"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="T:Fliker.BaseAPIProvider"/> in an unusable state. After calling
		/// <see cref="Dispose"/>, you must release all references to the <see cref="T:Fliker.BaseAPIProvider"/> so the
		/// garbage collector can reclaim the memory that the <see cref="T:Fliker.BaseAPIProvider"/> was occupying.</remarks>
		public void Dispose()
		{
			_http?.Dispose();
			_http = null;
		}
	}
}
