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
            return $"{Name.ToLowerInvariant()}-{Value?.ToString()?.ToLowerInvariant()}";
        }

        if (!string.IsNullOrWhiteSpace(DefaultName))
        {
            // generate a default id using default name and value
            return $"{DefaultName.ToLowerInvariant()}-{Value?.ToString()?.ToLowerInvariant()}";
        }

        // use the existing id
        return CascadedFieldContext?.InputId;
    }
}
