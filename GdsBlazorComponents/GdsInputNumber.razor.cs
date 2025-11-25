using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Linq.Expressions;

namespace GdsBlazorComponents;

public partial class GdsInputNumber<TNumberValue>
{
    [CascadingParameter]
    private string? CascadedId { get; set; }

    [Parameter, EditorRequired]
    public TNumberValue? NumberValue { get; set; } // Nullable just in case someone tries to use a non number type
    [Parameter]
    public EventCallback<TNumberValue> NumberValueChanged { get; set; }
    [Parameter]
    public Expression<Func<TNumberValue>>? NumberValueExpression { get; set; }

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public bool Show { get; set; } = true;

    private string? _inputmode;
    private string? _describedBy;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Id ??= CascadedId;
        if (Id != null)
        {
            _describedBy = $"{Id}-hint {Id}-error";
        }
        _inputmode = GetInputModeValue();
    }

    private static string? GetInputModeValue()
    {
        var targetType = Nullable.GetUnderlyingType(typeof(TNumberValue)) ?? typeof(TNumberValue);
        if (targetType == typeof(int) || targetType == typeof(long) || targetType == typeof(short))
        {
            return "numeric";
        }
        else if (targetType == typeof(float) || targetType == typeof(double) || targetType == typeof(decimal))
        {
            return null;
        }
        else
        {
            throw new InvalidOperationException($"The type '{targetType}' is not a supported {nameof(NumberValue)} type. Only int, long, short, float, double, and decimal are allowed.");
        }
    }

    /// <summary>
    /// Handles when the InputText value is set/changed.
    /// </summary>
    /// <remarks>Also sets NumberValue. Makes sure to set CurrentValueAsString last so that validation occurs after NumberValue is updated.</remarks>
    private async Task OnValueSet(string? newValue)
    {
        if (newValue != Value)
        {
            NumberValue = ParseNumberValue(newValue?.Trim());
            await NumberValueChanged.InvokeAsync(NumberValue);

            // Make sure this is called last, after NumberValueChanged has been called
            CurrentValueAsString = newValue;
        }    
    }

    /// <summary>
    /// Tries to convert the string InputText value into a number of type <typeparamref name="TNumberValue"/>.
    /// </summary>
    /// <remarks>Works out the type of <typeparamref name="TNumberValue"/> and converts it into that type if possible.</remarks>
    /// <returns>The parsed value of type <typeparamref name="TNumberValue"/> if the conversion is successful; otherwise, <see langword="default"/>.</returns>
    /// <exception cref="InvalidOperationException">Thrown if <typeparamref name="TNumberValue"/> is not a supported numeric type.</exception>
    private TNumberValue? ParseNumberValue(string? value)
    {
        object? result;
        bool success;

        Type? targetType = Nullable.GetUnderlyingType(typeof(TNumberValue)) ?? typeof(TNumberValue);
        if (targetType == typeof(int))
        {
            success = int.TryParse(value, CultureInfo.InvariantCulture, out var intVal);
            result = intVal;
        }
        else if (targetType == typeof(long))
        {
            success = long.TryParse(value, CultureInfo.InvariantCulture, out var longVal);
            result = longVal;
        }
        else if (targetType == typeof(short))
        {
            success = short.TryParse(value, CultureInfo.InvariantCulture, out var shortVal);
            result = shortVal;
        }
        else if (targetType == typeof(float))
        {
            success = float.TryParse(value, CultureInfo.InvariantCulture, out var floatVal);
            result = floatVal;
        }
        else if (targetType == typeof(double))
        {
            success = double.TryParse(value, CultureInfo.InvariantCulture, out var doubleVal);
            result = doubleVal;
        }
        else if (targetType == typeof(decimal))
        {
            success = decimal.TryParse(value, CultureInfo.InvariantCulture, out var decimalVal);
            result = decimalVal;
        }
        else
        {
            throw new InvalidOperationException($"The type '{targetType}' is not a supported {nameof(NumberValue)} type. Only int, long, short, float, double, and decimal are allowed.");
        }

        return success ? (TNumberValue)result : default;
    }
}
