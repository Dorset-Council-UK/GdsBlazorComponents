using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public abstract class GdsLabelBase : ComponentBase
{
    [CascadingParameter]
    private FieldContext? CascadedFieldContext { get; set; }

    /// <summary>
    ///     <para>Optionally override the 'for' attribute of the label.</para>
    ///     <para>If not set, <see cref="FieldContext" /> 'InputId' will be used, if available.</para>
    /// </summary>
    [Parameter]
    public string? For { get; set; }

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public GdsSize? Size { get; set; }

    /// <summary>
    /// Overrides the base GDS CSS class for this control (e.g. "govuk-label").
    /// If null, <see cref="BaseCssClass"/> is used.
    /// </summary>
    [Parameter]
    public string? CssClass { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    protected abstract string BaseCssClass { get; }

    protected string? ResolvedCssClass;

    protected string? ResolvedFor;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        string? sizeClass = Size switch
        {
            GdsSize.Small => "govuk-label--s",
            GdsSize.Medium => "govuk-label--m",
            GdsSize.Large => "govuk-label--l",
            GdsSize.ExtraLarge => "govuk-label--xl",
            _ => null,
        };

        string effectiveBaseCssClass = CssClass ?? BaseCssClass;
        ResolvedCssClass = new CssClassBuilder(effectiveBaseCssClass)
            .AddIf(sizeClass is not null, sizeClass)
            .Add(AdditionalCssClasses)
            .Build();

        // Calculate the For id
        if (!string.IsNullOrWhiteSpace(For))
        {
            // if For is set, use it
            ResolvedFor = For.Trim();
        }
        else
        {
            ResolvedFor = CascadedFieldContext?.InputId;
        }
    }
}
