namespace Fliker
{
	/// <summary>
	/// User.
	/// </summary>
	public interface IUser
	{
		string Id { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		byte[] Image { get; set; }
		string ImageURL { get; set; }
		string ImageId { get; set; }
	}
}
