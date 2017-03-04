using System;
using Newtonsoft.Json.Linq;

namespace Fliker
{
	/// <summary>
	/// Mapper.
	/// </summary>
	public class Mapper<TModel> : IMapper<TModel> where TModel : class
	{
		public TModel Map(JToken token)
		{
			Type modelType = typeof(TModel);

			var properties = modelType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			var instance = Activator.CreateInstance<TModel>();

			foreach (var property in properties)
			{
				var attr = Attribute.GetCustomAttribute(property, typeof(MappedToAttribute)) as MappedToAttribute;

				if (attr != null)
				{
					var value = token[attr.Property];

					if (value != null)
					{
						modelType.GetProperty(property.Name).SetValue(instance, value.ToObject(property.PropertyType));
					}
				}
			}

			return instance;
		}
	}
}
