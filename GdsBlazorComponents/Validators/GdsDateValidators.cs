using FluentValidation;

namespace GdsBlazorComponents.Validators;

public static class GdsDateValidators
{
    /// <summary>
    /// Whole date validator - Checks that the date is not empty and that day, month, and year parts are entered.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> NotEmpty<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        return ruleBuilder.Custom((date, context) =>
        {
            if (string.IsNullOrWhiteSpace(date.DayText) && string.IsNullOrWhiteSpace(date.MonthText) && string.IsNullOrWhiteSpace(date.YearText))
            {
                context.AddFailure(context.PropertyPath, $"Enter {context.DisplayName.ToLowerInvariant()}");
            }
        })
        .DayNotEmpty()
        .MonthNotEmpty()
        .YearNotEmpty();
    }

    /// <summary>
    /// Whole date validator - Checks that the day, month, and year parts of the date are all numbers.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> MustBeNumber<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        return ruleBuilder
            .DayMustBeNumber()
            .MonthMustBeNumber()
            .YearMustBeNumber();
    }
}
