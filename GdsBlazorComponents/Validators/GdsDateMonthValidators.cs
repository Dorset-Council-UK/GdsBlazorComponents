using FluentValidation;

namespace GdsBlazorComponents.Validators;

public static class GdsDateMonthValidators
{
    /// <summary>
    /// Month validator - Checks that the month text is not empty.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> MonthNotEmpty<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        return ruleBuilder
            .Must(date => !string.IsNullOrWhiteSpace(date.MonthText))
            .WithMessage("{PropertyName} must include a month")
            .OverridePropertyName("MonthText");
    }

    /// <summary>
    /// Month validator - Checks that the month is a number.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> MonthMustBeNumber<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        return ruleBuilder
            .Must(date => date.Month.HasValue)
            .WithMessage("{PropertyName} month must be a number")
            .OverridePropertyName("MonthText");
    }

    /// <summary>
    /// Month validator - Checks that the month is between the specified range (inclusive).
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> MonthInclusiveBetween<T>(this IRuleBuilder<T, GdsDate> ruleBuilder, int from = 1, int to = 12)
    {
        return ruleBuilder
            .Must((rootObject, date, context) =>
            {
                context.MessageFormatter
                    .AppendArgument("From", from)
                    .AppendArgument("To", to);

                return date.Month.HasValue && (date.Month.Value >= from && date.Month.Value <= to);
            })
            .WithMessage("{PropertyName} month must be between {From} and {To}")
            .OverridePropertyName("MonthText");
    }
}
