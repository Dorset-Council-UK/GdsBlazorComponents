using System.ComponentModel;
using System.Reflection;

namespace GdsBlazorComponents;

public enum GdsTagColour
{
    [Description("govuk-tag--blue")]
    Blue,

    [Description("govuk-tag--green")]
    Green,

    [Description("govuk-tag--grey")]
    Grey,

    [Description("govuk-tag--purple")]
    Purple,

    [Description("govuk-tag--red")]
    Red,

    [Description("govuk-tag--turquoise")]
    Turquoise,

    [Description("govuk-tag--yellow")]
    Yellow,

    [Description("govuk-tag--light-blue")]
    LightBlue,

    [Description("govuk-tag--pink")]
    Pink,

    [Description("govuk-tag--orange")]
    Orange
}

public static class GdsTagColourExtensions
{
    public static string GetValue<T>(this T enumValue) where T : Enum
    {
        return typeof(T).GetMember(enumValue.ToString()).First().GetCustomAttribute<DescriptionAttribute>()?.Description ?? enumValue.ToString();
    }
}