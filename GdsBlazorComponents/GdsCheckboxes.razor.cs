using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace GdsBlazorComponents;

public partial class GdsCheckboxes : IDisposable
{
    [CascadingParameter]
    private FieldContext? CascadedFieldContext { get; set; }

    /// <summary>
    /// Optional model field for group-level validation mapping (example: () => model.Waste).
    /// </summary>
    [Parameter]
    public Expression<Func<object>>? For { get; set; }

    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public bool Smaller { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    private string? _class;
    private string? _defaultName;
    private FieldIdentifier? _fieldIdentifier;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        _class = new CssClassBuilder("govuk-checkboxes")
            .AddIf(Smaller, "govuk-checkboxes--small")
            .Add(AdditionalCssClasses)
            .Build();

        if (For is not null)
        {
            _fieldIdentifier = FieldIdentifier.Create(For);
        }

        // if there is no Name parameter, or For expression provided, then the child InputCheckbox will auto handle the name attribute
        _defaultName = Name?.Trim() ?? _fieldIdentifier?.FieldName;

        // update the field context
        if (CascadedFieldContext is not null && _fieldIdentifier.HasValue)
        {
            CascadedFieldContext.InputId = _fieldIdentifier.Value.FieldName;
            CascadedFieldContext.RegisterField(_fieldIdentifier.Value);
            CascadedFieldContext.NotifyIfChanged();
        }
    }

    public void Dispose()
    {
        if (CascadedFieldContext is not null && _fieldIdentifier.HasValue)
        {
            CascadedFieldContext.UnregisterField(_fieldIdentifier.Value);
        }
        GC.SuppressFinalize(this);
    }
}
