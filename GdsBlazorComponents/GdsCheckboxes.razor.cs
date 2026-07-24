using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;

namespace GdsBlazorComponents;

public partial class GdsCheckboxes<TValue>
{
    [CascadingParameter]
    private FieldContext? CascadedFieldContext { get; set; }

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

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        _class = new CssClassBuilder("govuk-checkboxes")
            .AddIf(Smaller, "govuk-checkboxes--small")
            .Add(AdditionalCssClasses)
            .Build();

        //_defaultName = Name
        //    ?? NameAttributeValue
        //    ?? FieldIdentifier.FieldName
        //    ?? Guid.NewGuid().ToString("N");

        // update the field context
        if (CascadedFieldContext is not null)
        {
            //CascadedFieldContext.InputId = FieldIdentifier.FieldName;
            //CascadedFieldContext.RegisterField(FieldIdentifier);
            //CascadedFieldContext.NotifyIfChanged();
        }
    }

    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
        => throw new NotSupportedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");

    //public void Dispose()
    //{
    //    CascadedFieldContext?.UnregisterField(FieldIdentifier);
    //    GC.SuppressFinalize(this);
    //}
}
