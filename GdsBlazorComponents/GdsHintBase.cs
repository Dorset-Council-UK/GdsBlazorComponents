using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public abstract class GdsHintBase : ComponentBase
{
    [CascadingParameter]
    private FieldContext? CascadedFieldContext { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    ///     <para>Optionally override the 'id' attribute of the hint.</para>
    ///     <para>If not set, a default hint id will be generated and stored in <see cref="FieldContext" /> 'HintId', if available.</para>
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public bool Show { get; set; } = true;

    /// <summary>
    /// Overrides the base GDS CSS class for this control (e.g. "govuk-hint").
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

    protected string? ResolvedHintId;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        string effectiveBaseCssClass = CssClass ?? BaseCssClass;
        ResolvedCssClass = new CssClassBuilder(effectiveBaseCssClass)
            .Add(AdditionalCssClasses)
            .Build();

        // Calculate the hint id
        if (!string.IsNullOrWhiteSpace(Id))
        {
            // if id is set, use it
            ResolvedHintId = Id.Trim();
        }
        else if (!string.IsNullOrWhiteSpace(CascadedFieldContext?.InputId))
        {
            // generate a default hint id
            ResolvedHintId = $"{CascadedFieldContext.InputId}-hint";
        }
        else
        {
            // use the existing hint id
            ResolvedHintId = CascadedFieldContext?.HintId;
        }

        // update the field context
        if (CascadedFieldContext is not null)
        {
            CascadedFieldContext.HintId = Show ? ResolvedHintId : null;
            CascadedFieldContext.NotifyIfChanged();
        }
    }
}
