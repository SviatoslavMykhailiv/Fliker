using System;
using System.Threading.Tasks;

namespace Fliker
{
	/// <summary>
	/// FBA pi service.
	/// </summary>
	public class FBApiService : BaseAPIProvider
	{
		protected override string BaseAPIURL
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override Task<IUser> GetUser(string id = null)
		{
			throw new NotImplementedException();
		}

		public override Task Like(string itemId)
		{
			throw new NotImplementedException();
		}
	}
}
