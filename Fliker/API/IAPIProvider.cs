using System.Threading.Tasks;

namespace Fliker
{
	/// <summary>
	/// APIP rovider.
	/// </summary>
	public interface IAPIProvider
	{
		/// <summary>
		/// Gets the user.
		/// </summary>
		/// <returns>The user.</returns>
		/// <param name="id">Identifier.</param>
		Task<IUser> GetUser(string id = null);

		/// <summary>
		/// Like the specified itemId.
		/// </summary>
		/// <param name="itemId">Item identifier.</param>
		Task Like(string itemId);
	}
}
