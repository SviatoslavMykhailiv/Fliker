using Newtonsoft.Json.Linq;

namespace Fliker
{
	/// <summary>
	/// Mapper.
	/// </summary>
	public interface IMapper<TModel> where TModel : class
	{
		TModel Map(JToken token);
	}
}
