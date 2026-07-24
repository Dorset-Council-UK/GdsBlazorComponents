using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public partial class GdsInputCheckbox : IDisposable
{
    [CascadingParameter]
    private FieldContext? CascadedFieldContext { get; set; }

    [CascadingParameter(Name = "DefaultName")]
    private string? DefaultName { get; set; }

    /// <summary>
    ///     <para>Optionally override the 'id' attribute of the checkbox control.</para>
    ///     <para>If not set, a default id will be generated and stored in <see cref="FieldContext" /> 'InputId', if available.</para>
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public bool Exclusive { get; set; }

    [Parameter]
    public string? ConditionalId { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    private string? _class;
    private string? _resolvedId;
    private string? _resolvedName;
    private string? _behaviour;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        _class = new CssClassBuilder("govuk-checkboxes__input")
            .Add(AdditionalCssClasses)
            .Build();

        _resolvedId = CalculateId();
        _resolvedName = Name ?? DefaultName ?? NameAttributeValue;
        _behaviour = Exclusive ? "exclusive" : null;

        // update the field context
        if (CascadedFieldContext is not null)
        {
            CascadedFieldContext.InputId = _resolvedId;
            CascadedFieldContext.RegisterField(FieldIdentifier);
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

        if (string.IsNullOrWhiteSpace(CascadedFieldContext?.InputId))
        {
            // generate a default id
            return FieldIdentifier.FieldName;
        }

        // use the existing id
        return CascadedFieldContext?.InputId;
    }
}
