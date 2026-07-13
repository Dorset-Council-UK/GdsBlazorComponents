using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace GdsBlazorComponents;

public partial class GdsFormGroup : IDisposable
{
    [CascadingParameter]
    private EditContext? EditContext { get; set; }

    [Parameter, EditorRequired]
    public required Expression<Func<object>> For { get; set; }

    /// <summary>
    ///     <para>Optionally override the 'id' attribute of the form control.</para>
    ///     <para>If not set, a default form control id will be generated and stored in <see cref="GdsFormGroupContext" /> 'Id'.</para>
    /// </summary>
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

    private GdsFormGroupContext FormGroupContext = default!;
    private const string GroupCssClass = "govuk-form-group";
    private const string GroupErrorCssClass = "govuk-form-group--error";

    private string? _class;
    private bool _hasError;

    protected override void OnInitialized()
    {
        FormGroupContext = new GdsFormGroupContext(StateHasChanged);
        EditContext?.OnValidationStateChanged += HandleValidationStateChanged;
    }

    protected override void OnParametersSet()
    {
        FieldIdentifier fieldIdentifier = FieldIdentifier.Create(For);
        FormGroupContext.FieldIdentifier = fieldIdentifier;
        FormGroupContext.Id = string.IsNullOrWhiteSpace(Id) ? fieldIdentifier.FieldName : Id;

        _class = new CssClassBuilder(GroupCssClass)
            .AddIf(_hasError, GroupErrorCssClass)
            .Add(AdditionalCssClasses)
            .Build();
    }

    private void HandleValidationStateChanged(object? sender, ValidationStateChangedEventArgs e)
    {
        FieldIdentifier? fieldIdentifier = FormGroupContext?.FieldIdentifier;
        _hasError = fieldIdentifier.HasValue &&
            EditContext is not null &&
            EditContext.GetValidationMessages(fieldIdentifier.Value).Any();

        OnParametersSet();
        StateHasChanged();
    }

    public void Dispose()
    {
        EditContext?.OnValidationStateChanged -= HandleValidationStateChanged;
        GC.SuppressFinalize(this);
    }
}
