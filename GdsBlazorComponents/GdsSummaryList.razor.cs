using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public partial class GdsSummaryList
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter]
    public bool NoBorder { get; set; }

    private string? _class;

    protected override void OnParametersSet()
    {
        _class = new CssClassBuilder("govuk-summary-list")
            .AddIf(NoBorder, "govuk-summary-list--no-border")
            .Add(AdditionalCssClasses)
            .Build();
    }
}