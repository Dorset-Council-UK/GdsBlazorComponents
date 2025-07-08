using GdsBlazorComponents;
using System.Globalization;

namespace FluentValidation;

public static class GdsDateDayValidators
{
    /// <summary>
    /// Day validator - Checks that the day text is not empty.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> DayNotEmpty<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        string? propertyDisplayName = null;

        return ruleBuilder
            .Custom((o, context) =>
            {
                if (GdsDateValidators.ParentDisplayNameChanged(context))
                {
                    propertyDisplayName = context.DisplayName;
                }
            })
            .ChildRules(date =>
            {
                date.RuleFor(o => o.DayText)
                    .NotEmpty()
                    .WithMessage("{PropertyName} must include a day")
                    .WithName(o => propertyDisplayName ?? nameof(o.DayText));
            });
    }

    /// <summary>
    /// Day validator - Checks that the day is a number.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> DayMustBeNumber<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        string? propertyDisplayName = null;

        return ruleBuilder
            .Custom((o, context) =>
            {
                if (GdsDateValidators.ParentDisplayNameChanged(context))
                {
                    propertyDisplayName = context.DisplayName;
                }
            })
            .ChildRules(date =>
            {
                date.RuleFor(o => o.Day)
                    .NotEmpty()
                    .WithMessage("{PropertyName} day must be a number")
                    .OverridePropertyName(o => o.DayText)
                    .WithName(o => propertyDisplayName ?? nameof(o.DayText));
            });
    }

    /// <summary>
    /// Day validator - Checks that the day is between the specified range (inclusive).
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> DayInclusiveBetween<T>(this IRuleBuilder<T, GdsDate> ruleBuilder, int from = 1, int to = 31)
    {
        string? propertyDisplayName = null;

        return ruleBuilder
            .Custom((o, context) =>
            {
                if (GdsDateValidators.ParentDisplayNameChanged(context))
                {
                    propertyDisplayName = context.DisplayName;
                }
            })
            .ChildRules(date =>
            {
                date.RuleFor(o => o.Day)
                    .InclusiveBetween(from, to)
                    .WithMessage("{PropertyName} day must be between {From} and {To}")
                    .OverridePropertyName(o => o.DayText)
                    .WithName(o => propertyDisplayName ?? nameof(o.DayText));
            });
    }

    /// <summary>
    /// Day validator - Checks that the month has enough days. The day, month, and year parts are needed to validate this.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> CorrectDaysInMonth<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
    {
        string? propertyDisplayName = null;

        return ruleBuilder
            .Custom((o, context) =>
            {
                if (GdsDateValidators.ParentDisplayNameChanged(context))
                {
                    propertyDisplayName = context.DisplayName;
                }
            })
            .ChildRules(date =>
            {
                date.RuleFor(o => o)
                    .Must((o, date, context) =>
                    {
                        if ((date.Day is null or < 1 or > 31) || (date.Month is null or < 1 or > 12) || date.Year is null)
                        {
                            context.MessageFormatter
                                .AppendArgument("MonthName", "unknown month")
                                .AppendArgument("Days", "unknown");
                            return false;
                        }

                        var day = date.Day.Value;
                        var month = date.Month.Value;
                        var year = date.Year.Value;

                        context.MessageFormatter
                            .AppendArgument("MonthName", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month))
                            .AppendArgument("Days", day);

                        return day <= DateTime.DaysInMonth(year, month);

                    })
                    .WithMessage("{PropertyName} {MonthName} does not have {Days} days")
                    .OverridePropertyName(o => o.DayText)
                    .WithName(o => propertyDisplayName ?? nameof(o.DayText));
            });
    }
}
