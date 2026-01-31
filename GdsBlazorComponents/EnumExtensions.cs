using System.ComponentModel;
using System.Reflection;

namespace GdsBlazorComponents;

internal static class EnumExtensions
{
	public static string? GetDescription<T>(this T enumValue) where T : Enum
	{
		return typeof(T).GetMember(enumValue.ToString()).First().GetCustomAttribute<DescriptionAttribute>()?.Description;
	}
}