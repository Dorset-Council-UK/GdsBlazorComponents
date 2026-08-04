using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public partial class GdsInputRadio<TValue>
{
    [CascadingParameter]
    private FieldContext? CascadedFieldContext { get; set; }

    [CascadingParameter(Name = "DefaultName")]
    private string? DefaultName { get; set; }

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? ConditionalId { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    private string? _resolvedId;
    private string? _class;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        _class = new CssClassBuilder("govuk-radios__input")
            .Add(AdditionalCssClasses)
            .Build();

        _resolvedId = CalculateId();

        // update the field context
        if (CascadedFieldContext is not null)
        {
            CascadedFieldContext.InputId = _resolvedId;
            CascadedFieldContext.NotifyIfChanged();
        }
    }

    private string? CalculateId()
    {
        // Calculate the id
        if (!string.IsNullOrWhiteSpace(Id))
        {
            // if id is set, use it
            return Id.Trim();
        }

        if (!string.IsNullOrWhiteSpace(Name))
        {
            // generate a default id using name and value
            return IdFrom(Name, Value);
        }

        if (!string.IsNullOrWhiteSpace(DefaultName))
        {
            // generate a default id using default name and value
            return IdFrom(DefaultName, Value);
        }

        // use the existing id
        return CascadedFieldContext?.InputId;
    }

    /// <summary>
    /// Generates an id from the given name and value.
    /// Checks name and value for null or whitespace, lowercases them, and replaces whitespace with hyphens.
    /// Example "{name}-{value}"
    /// </summary>
    private string? IdFrom(string name, TValue? value)
    {
        if (value is null)
        {
            return null;
        }

        ReadOnlySpan<char> nameSpan = name.AsSpan().Trim();
        ReadOnlySpan<char> valueSpan = value.ToString().AsSpan().Trim();

        int size = nameSpan.IsEmpty ? valueSpan.Length : nameSpan.Length + 1 + valueSpan.Length;
        Span<char> combined = stackalloc char[size];
        
        if (nameSpan.IsEmpty)
        {
            valueSpan.CopyTo(combined);
        }
        else
        {
            nameSpan.CopyTo(combined);
            combined[nameSpan.Length] = '-';
            valueSpan.CopyTo(combined[(nameSpan.Length + 1)..]);
        }

        for (int i = 0; i < size; i++)
        {
            char c = combined[i];
            combined[i] = char.IsWhiteSpace(c) ? '-' : char.ToLowerInvariant(c);
        }

        return new string(combined);
    }
}
