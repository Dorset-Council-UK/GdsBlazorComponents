using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public partial class GdsSummaryCardAction
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    private string? _class;

    protected override void OnParametersSet()
    {
        _class = new CssClassBuilder("govuk-summary-card__action")
            .Add(AdditionalCssClasses)
            .Build();
    }
}