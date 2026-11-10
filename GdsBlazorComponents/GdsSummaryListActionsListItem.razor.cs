using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public partial class GdsSummaryListActionsListItem
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
        _class = new CssClassBuilder("govuk-summary-list__actions-list-item")
            .Add(AdditionalCssClasses)
            .Build();
    }
}