using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace GdsBlazorComponents;

public partial class GdsRadios<TValue> : IDisposable
{
    [CascadingParameter]
    private FieldContext? CascadedFieldContext { get; set; }

    [Parameter]
    public bool Smaller { get; set; }

    [Parameter]
    public bool Inline { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    private string? _class;
    private string? _defaultName;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        _class = new CssClassBuilder("govuk-radios")
            .AddIf(Inline, "govuk-radios--inline")
            .AddIf(Smaller, "govuk-radios--small")
            .Add(AdditionalCssClasses)
            .Build();

        _defaultName = Name ?? NameAttributeValue;

        // update the field context
        if (CascadedFieldContext is not null)
        {
            CascadedFieldContext.InputId = FieldIdentifier.FieldName;
            CascadedFieldContext.RegisterField(FieldIdentifier);
            CascadedFieldContext.NotifyIfChanged();
        }
    }

    public void Dispose()
    {
        CascadedFieldContext?.UnregisterField(FieldIdentifier);
        GC.SuppressFinalize(this);
    }
}
