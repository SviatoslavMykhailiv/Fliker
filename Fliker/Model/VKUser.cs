namespace Fliker
{
	/// <summary>
	/// VKU ser.
	/// </summary>
	public class VKUser : IUser
	{
		[MappedTo("first_name")]
		public virtual string FirstName { get; set; }

		[MappedTo("uid")]
		public virtual string Id { get; set; }

		[MappedTo("photo_100")]
		public virtual string ImageURL { get; set; }

		[MappedTo("last_name")]
		public virtual string LastName { get; set; }

		public byte[] Image { get; set; }

		[MappedTo("photo_id")]
		public virtual string ImageId { get; set; }
	}
}
