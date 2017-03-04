namespace Fliker
{
	public interface ICache
	{
		TModel Load<TModel>(string key) where TModel : class;
		void Store<TModel>(TModel model, string key) where TModel : class;
		void Remove(string key);
	}
}
