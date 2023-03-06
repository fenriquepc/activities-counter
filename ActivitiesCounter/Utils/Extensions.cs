using System.ComponentModel;
using System.Text.Json;

namespace ActivitiesCounter.Utils;

public static class Extensions
{
    public static string GetDescription(this Enum enumValue)
    {
        var field = enumValue.GetType().GetField(enumValue.ToString());
        if (field == null)
            return enumValue.ToString();

        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            return attribute.Description;

        return enumValue.ToString();
    }

	public static T Copy<T>(this T obj)
	{
        var serialized = JsonSerializer.Serialize(obj);
		var copy = JsonSerializer.Deserialize<T>(serialized);

        return copy;
	}
}
