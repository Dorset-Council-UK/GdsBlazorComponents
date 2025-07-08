using GdsBlazorComponents;
using GdsBlazorComponents.Validators;

namespace FluentValidation;

public static class GdsDateValidators
{
    /// <summary>
    /// Whole date validator - Checks that the date is not empty and that day, month, and year parts are entered.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> DayMonthYearNotEmpty<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new DayMonthYearNotEmptyValidator<T, GdsDate>());
    }

    /// <summary>
    /// Whole date validator - Checks that the date is a real date, meaning that the day, month, and year parts are valid together.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> IsRealDate<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new IsRealDateValidator<T, GdsDate>());
    }

    /// <summary>
    /// Work out if WithName was used to change the display name of the parent property.
    /// </summary>
    internal static bool ParentDisplayNameChanged<T>(ValidationContext<T> context)
    {
        var displayNameNoSpaces = context.DisplayName.Replace(" ", string.Empty);
        return !context.PropertyPath.Equals(displayNameNoSpaces, StringComparison.OrdinalIgnoreCase);
    }
}
