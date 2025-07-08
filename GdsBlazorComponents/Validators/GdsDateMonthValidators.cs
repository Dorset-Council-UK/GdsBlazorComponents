using GdsBlazorComponents;

namespace FluentValidation;

public static class GdsDateMonthValidators
{
    /// <summary>
    /// Month validator - Checks that the month text is not empty.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> MonthNotEmpty<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
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
                date.RuleFor(o => o.MonthText)
                    .NotEmpty()
                    .WithMessage("{PropertyName} must include a month")
                    .WithName(o => propertyDisplayName ?? nameof(o.MonthText));
            });
    }

    /// <summary>
    /// Month validator - Checks that the month is a number.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> MonthMustBeNumber<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
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
                date.RuleFor(o => o.Month)
                    .NotEmpty()
                    .WithMessage("{PropertyName} month must be a number")
                    .OverridePropertyName(o => o.MonthText)
                    .WithName(o => propertyDisplayName ?? nameof(o.MonthText));
            });
    }

    /// <summary>
    /// Month validator - Checks that the month is between the specified range (inclusive).
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> MonthInclusiveBetween<T>(this IRuleBuilder<T, GdsDate> ruleBuilder, int from = 1, int to = 12)
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
                date.RuleFor(o => o.Month)
                    .InclusiveBetween(from, to)
                    .WithMessage("{PropertyName} month must be between {From} and {To}")
                    .OverridePropertyName(o => o.MonthText)
                    .WithName(o => propertyDisplayName ?? nameof(o.MonthText));
            });
    }
}
