using FluentValidation;
using FluentValidation.Validators;

namespace GdsBlazorComponents.Validators;

public class IsRealDateValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    public override string Name => "IsRealDate";

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

        if (date.Day == null || date.Month == null || date.Year == null)
        {
            return false;
        }

        if (date.DateUtc == null || date.DateUtc.Value == DateTime.MinValue)
        {
            return false;
        }

        return !EqualityComparer<TProperty>.Default.Equals(value, default);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) => "{PropertyName} must be a real date";
}
