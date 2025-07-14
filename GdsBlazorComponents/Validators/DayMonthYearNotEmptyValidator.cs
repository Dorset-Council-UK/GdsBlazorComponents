using FluentValidation;
using FluentValidation.Validators;

namespace GdsBlazorComponents.Validators;

public class DayMonthYearNotEmptyValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    public override string Name => "DayMonthYearNotEmpty";

    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        if (value == null)
        {
            return false;
        }

        if (value is not GdsDate date)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(date.DayText))
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(date.MonthText))
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(date.YearText))
        {
            return false;
        }

        return !EqualityComparer<TProperty>.Default.Equals(value, default);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) => "Enter {PropertyName}";
}
