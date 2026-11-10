using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public partial class GdsSummaryCardTitle
{
    [Parameter]
    public RenderFragment? Children { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter, EditorRequired]
    public int Level { get; set; }

    [Parameter]
    public GdsSize? Size { get; set; }
}