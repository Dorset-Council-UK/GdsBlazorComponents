using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public abstract class GdsDividerBase : ComponentBase
{
    [Parameter]
    public string Text { get; set; } = "or";

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    protected abstract string BaseCssClass { get; }

    protected string? CssClass => new CssClassBuilder(BaseCssClass)
        .Add(AdditionalCssClasses)
        .Build();
}
