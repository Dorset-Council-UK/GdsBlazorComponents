using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public partial class GdsCheckboxItem
{
    [CascadingParameter]
    private FieldContext? CascadedParentFieldContext { get; set; }
    
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    private FieldContext FieldContext = default!;
    private string? _class;

    protected override void OnInitialized()
    {
        FieldContext = new FieldContext(StateHasChanged)
        {
            Parent = CascadedParentFieldContext ?? null,
        };
    }

    protected override void OnParametersSet()
    {
        _class = new CssClassBuilder("govuk-checkboxes__item")
            .Add(AdditionalCssClasses)
            .Build();
    }
}
