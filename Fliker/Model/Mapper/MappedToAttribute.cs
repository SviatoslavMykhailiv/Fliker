using System;
namespace Fliker
{
	/// <summary>
	/// Mapped to attribute.
	/// </summary>
	public class MappedToAttribute : Attribute
	{
		public string Property { get; private set; }

		public MappedToAttribute(string property)
		{
			Property = property;
		}
	}
}
