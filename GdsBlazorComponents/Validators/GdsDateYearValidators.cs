using GdsBlazorComponents;

namespace FluentValidation;

public static class GdsDateYearValidators
{
    /// <summary>
    /// Year validator - Checks that the year text is not empty.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> YearNotEmpty<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
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
                date.RuleFor(o => o.YearText)
                    .NotEmpty()
                    .WithMessage("{PropertyName} must include a year")
                    .WithName(o => propertyDisplayName ?? nameof(o.YearText));
            });
    }

    /// <summary>
    /// Year validator - Checks that the year is a number.
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> YearMustBeNumber<T>(this IRuleBuilder<T, GdsDate> ruleBuilder)
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
                date.RuleFor(o => o.Year)
                    .NotEmpty()
                    .WithMessage("{PropertyName} year must be a number")
                    .OverridePropertyName(o => o.YearText)
                    .WithName(o => propertyDisplayName ?? nameof(o.YearText));
            });
    }

    /// <summary>
    /// Year validator - Checks that the year is between the specified range (inclusive).
    /// </summary>
    public static IRuleBuilderOptions<T, GdsDate> YearInclusiveBetween<T>(this IRuleBuilder<T, GdsDate> ruleBuilder, int from, int to)
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
                date.RuleFor(o => o.Year)
                    .InclusiveBetween(from, to)
                    .WithMessage("{PropertyName} year must be between {From} and {To}")
                    .OverridePropertyName(o => o.YearText)
                    .WithName(o => propertyDisplayName ?? nameof(o.YearText));
            });
    }
}
