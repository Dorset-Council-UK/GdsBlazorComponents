using FluentValidation;
using System.Globalization;

namespace GdsBlazorComponents.Validators;

public static class GdsDateDayValidators
{
    /// <summary>
    /// Day validator - Checks that the day text is not empty.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> DayNotEmpty<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        return ruleBuilder
            .Must(date => !string.IsNullOrWhiteSpace(date.DayText))
            .WithMessage("{PropertyName} must include a day")
            .OverridePropertyName("DayText");
    }

    /// <summary>
    /// Day validator - Checks that the day is a number.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> DayMustBeNumber<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        return ruleBuilder
            .Must(date => date.Day.HasValue)
            .WithMessage("{PropertyName} day must be a number")
            .OverridePropertyName("DayText");
    }

    /// <summary>
    /// Day validator - Checks that the day is between the specified range (inclusive).
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> DayInclusiveBetween<T>(this IRuleBuilder<T, GdsDate> ruleBuilder, int from = 1, int to = 31)
    {
        return ruleBuilder
            .Must((o, date, context) =>
            {
                context.MessageFormatter
                    .AppendArgument("From", from)
                    .AppendArgument("To", to);

                return date.Day.HasValue && (date.Day.Value >= from && date.Day.Value <= to);
            })
            .WithMessage("{PropertyName} day must be between {From} and {To}")
            .OverridePropertyName("DayText");
    }


    /// <summary>
    /// Day validator - Checks that the month has enough days. The day, month, and year parts are needed to validate this.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> DaysInMonth<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        //.DayMustBeNumber()
        //.MonthMustBeNumber()
        //.YearMustBeNumber()
        return ruleBuilder
            .Must((o, date, context) =>
            {
                var day = date.Day.Value;
                var month = date.Month.Value;
                var year = date.Year.Value;

                context.MessageFormatter
                    .AppendArgument("MonthName", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month))
                    .AppendArgument("Days", day);

                return day < DateTime.DaysInMonth(year, month);

            })
            .WithMessage("{PropertyName} {MonthName} does not have {Days} days")
            .OverridePropertyName("DayText");
    }
}
