using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace GdsBlazorComponents;

public partial class GdsFormGroup : IDisposable
{
    [CascadingParameter]
    private EditContext? EditContext { get; set; }

    [Parameter]
    [Obsolete("Deprecated in v3.5.0. Using a form control as a child of GdsFormGroup will be automatically detected. It will be removed in future versions.")]
    public Expression<Func<object>>? For { get; set; }

    [Obsolete("Deprecated in v3.5.0. Using a form control as a child of GdsFormGroup will be automatically detected. It will be removed in future versions.")]
    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public bool Show { get; set; } = true;

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter]
    public string? DataModule { get; set; } = null;

    [Parameter]
    public string? DataMaxLength { get; set; } = null;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private FieldContext FieldContext = default!;
    private const string GroupCssClass = "govuk-form-group";
    private const string GroupErrorCssClass = "govuk-form-group--error";

    private string? _class;
    private bool _hasError;

    protected override void OnInitialized()
    {
        FieldContext = new FieldContext(StateHasChanged);
        EditContext?.OnValidationStateChanged += HandleValidationStateChanged;
    }

    protected override void OnParametersSet()
    {
        BuildCssClasses();
    }

    private void BuildCssClasses()
    {
        _class = new CssClassBuilder(GroupCssClass)
            .AddIf(_hasError, GroupErrorCssClass)
            .Add(AdditionalCssClasses)
            .Build();
    }

    private void HandleValidationStateChanged(object? sender, ValidationStateChangedEventArgs e)
    {
        if (EditContext is null)
        {
            return;
        }

        _hasError = FieldContext.FieldIdentifiers.Any(fi => EditContext.GetValidationMessages(fi).Any());

        BuildCssClasses();
        StateHasChanged();
    }

    public void Dispose()
    {
        EditContext?.OnValidationStateChanged -= HandleValidationStateChanged;
        GC.SuppressFinalize(this);
    }
}
