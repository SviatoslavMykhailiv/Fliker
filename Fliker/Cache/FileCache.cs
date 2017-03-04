using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Fliker
{
	public class FileCache : ICache
	{
		#region private consts

		const string JSON_EXTENSION = ".json";

		#endregion

		#region implementation

		public TModel Load<TModel>(string key) where TModel : class
		{
			var path = GetPath(key);

			if (File.Exists(path))
			{
				string serialized;

				using (var streamReader = new StreamReader(path))
				{
					serialized = streamReader.ReadToEnd();
				}

				if (string.IsNullOrEmpty(serialized))
				{
					return null;
				}

				var json = JObject.Parse(serialized);
				var model = json.ToObject<TModel>();

				return model;
			}

			return null;
		}

		public void Remove(string key)
		{
			var path = GetPath(key);

			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}

		public void Store<TModel>(TModel model, string key) where TModel : class
		{
			Remove(key);

			var path = GetPath(key);

			if (model != null)
			{
				var serialized = JObject.FromObject(model);

				using (var streamWriter = new StreamWriter(File.Create(path)))
				{
					streamWriter.WriteLineAsync(serialized.ToString());
				}
			}
		}

		#endregion

		#region helper methods

		static string GetPath(string key)
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), string.Format("{0}{1}", key, JSON_EXTENSION));
		}

		#endregion

		FileCache()
		{
		}

		static ICache _instance;

		public static ICache Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new FileCache();
				}

				return _instance;
			}
		}
	}
}
