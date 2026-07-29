using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace GdsBlazorComponents;

public partial class GdsErrorMessage : IDisposable
{
    [CascadingParameter]
    public EditContext? CascadedEditContext { get; set; }

    [CascadingParameter]
    private FieldContext? CascadedFieldContext { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    ///     <para>Optionally override the 'id' attribute of the error message.</para>
    ///     <para>If not set, a default error message id will be generated and stored in <see cref="FieldContext" /> 'ErrorId', if available.</para>
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    private string? _class;
    private string? _resolvedErrorId;
    private bool _showError;
    private string? _errorMessage;

    protected override void OnInitialized()
    {
        if (CascadedEditContext is null)
        {
            throw new InvalidOperationException($"{nameof(EditContext)} is required for {nameof(GdsErrorMessage)}. Use {nameof(GdsErrorMessage)} inside an {nameof(EditForm)}.");
        }

        CascadedEditContext.OnValidationStateChanged += HandleValidationStateChanged;
    }

    protected override void OnParametersSet()
    {
        _class = new CssClassBuilder("govuk-error-message")
            .Add(AdditionalCssClasses)
            .Build();

        CalculateErrorId();
    }

    private void CalculateErrorId()
    {
        // Calculate the error message id
        if (!string.IsNullOrWhiteSpace(Id))
        {
            // if id is set, use it
            _resolvedErrorId = Id.Trim();
        }
        else if (!string.IsNullOrWhiteSpace(CascadedFieldContext?.InputId))
        {
            // generate a default error message id
            _resolvedErrorId = $"{CascadedFieldContext.InputId}-error";
        }
        else
        {
            // use the existing error id
            _resolvedErrorId = CascadedFieldContext?.ErrorId;
        }

        // update the field context
        if (CascadedFieldContext is not null)
        {
            CascadedFieldContext.ErrorId = _showError ? _resolvedErrorId : null;
            CascadedFieldContext.NotifyIfChanged();
        }
    }

    private void HandleValidationStateChanged(object? sender, ValidationStateChangedEventArgs e)
    {
        if (CascadedEditContext is null || CascadedFieldContext is null)
        {
            return;
        }

        _showError = false;
        _errorMessage = null;

        foreach (var fieldIdentifier in CascadedFieldContext.FieldIdentifiers)
        {
            var messages = CascadedEditContext.GetValidationMessages(fieldIdentifier);
            if (messages.Any())
            {
                _showError = true;
                _errorMessage = messages.FirstOrDefault();
                break;
            }
        }

        CalculateErrorId();
        StateHasChanged();
    }

    public void Dispose()
    {
        CascadedEditContext?.OnValidationStateChanged -= HandleValidationStateChanged;
        GC.SuppressFinalize(this);
    }
}
