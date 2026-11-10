using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public partial class GdsSummaryListRow
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter]
    public bool NoBorder { get; set; }

    [Parameter]
    public bool NoActions { get; set; }

    private string? _class;

    protected override void OnParametersSet()
    {
        _class = new CssClassBuilder("govuk-summary-list__row")
            .AddIf(NoBorder, "govuk-summary-list__row--no-border")
            .AddIf(NoActions, "govuk-summary-list__row--no-actions")
            .Add(AdditionalCssClasses)
            .Build();
    }
}