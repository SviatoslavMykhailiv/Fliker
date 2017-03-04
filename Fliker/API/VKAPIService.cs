using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Fliker
{
	/// <summary>
	/// VKAPIS ervice.
	/// </summary>
	public class VKAPIService : BaseAPIProvider
	{
		/// <summary>
		/// Gets the base apiurl.
		/// </summary>
		/// <value>The base apiurl.</value>
		protected override string BaseAPIURL
		{
			get
			{
				return "https://api.vk.com/method/";
			}
		}

		/// <summary>
		/// Gets the user.
		/// </summary>
		/// <returns>The user.</returns>
		/// <param name="id">Identifier.</param>
		public async override Task<IUser> GetUser(string id = null)
		{
			var user = new Mapper<VKUser>()
				.Map(JObject.Parse(await base.Post(string.Format("{0}{1}", BaseAPIURL, "users.get"),
												   new Dictionary<string, string>
															{
																{ "user_ids", id ?? Context.Secret.ClientId },
																{ "fields", "photo_id,photo_100" },
																{ "access_token", Context.Secret.Token }
															}))
					 ["response"]
					 .ToList()
					 .FirstOrDefault());

			user.Image = await base.GetAsBytes(user.ImageURL);

			return user;
		}

		/// <summary>
		/// Like the specified itemId. Item is combination of VK user id and it's picture id like 484948948_93839383,
		/// so we need to split itemid by underscore sign
		/// </summary>
		/// <param name="itemId">Item identifier.</param>
		public override Task Like(string itemId)
		{
			var ids = itemId.Split('_');

			return base.Post(string.Format("{0}{1}", BaseAPIURL, "likes.add"),
							 new Dictionary<string, string>
									{
										{ "type", "photo" },
										{ "owner_id", ids.First() },
										{ "item_id", ids.Last() },
										{ "access_token", Context.Secret.Token }
									}
							);
		}
	}
}
