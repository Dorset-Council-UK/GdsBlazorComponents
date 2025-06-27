using FluentValidation;

namespace GdsBlazorComponents.Validators;

public static class GdsDateYearValidators
{
    /// <summary>
    /// Year validator - Checks that the year text is not empty.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> YearNotEmpty<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        return ruleBuilder
            .Must(date => !string.IsNullOrWhiteSpace(date.YearText))
            .WithMessage("{PropertyName} must include a year")
            .OverridePropertyName("YearText");
    }

    /// <summary>
    /// Year validator - Checks that the year is a number.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> YearMustBeNumber<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        return ruleBuilder
            .Must(date => date.Year.HasValue)
            .WithMessage("{PropertyName} year must be a number")
            .OverridePropertyName("YearText");
    }

    /// <summary>
    /// Year validator - Checks that the year is between the specified range (inclusive).
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> YearInclusiveBetween<T>(this IRuleBuilder<T, GdsDate> ruleBuilder, int from, int to)
    {
        return ruleBuilder
            .Must((rootObject, date, context) =>
            {
                context.MessageFormatter
                    .AppendArgument("From", from)
                    .AppendArgument("To", to);

                return date.Year.HasValue && (date.Year.Value >= from && date.Year.Value <= to);
            })
            .WithMessage("{PropertyName} year must be between {From} and {To}")
            .OverridePropertyName("YearText");
    }
}
