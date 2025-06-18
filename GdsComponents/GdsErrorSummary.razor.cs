using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FloodOnlineReportingTool.GdsComponents;

/// <summary>
/// A customised error summary component that displays GDS style validation errors.
/// </summary>
/// <remarks>Based on <see href="https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/ValidationSummary.cs" /></remarks>
public partial class GdsErrorSummary : IDisposable
{
    [CascadingParameter]
    EditContext CurrentEditContext { get; set; } = default!;

    private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;

    public GdsErrorSummary()
    {
        _validationStateChangedHandler = (sender, args) => OnValidationStateChanged();
    }

    public void Dispose()
    {
        try
        {
            // Unsubscribe from validation state changes
            CurrentEditContext.OnValidationStateChanged -= _validationStateChangedHandler;
        }
        catch (Exception)
        {
        }

        GC.SuppressFinalize(this);
    }

    protected override void OnInitialized()
    {
        // Subscribe to validation state changes
        CurrentEditContext.OnValidationStateChanged += _validationStateChangedHandler;
    }

    protected override void OnParametersSet()
    {
        if (CurrentEditContext == null)
        {
            throw new InvalidOperationException($"{nameof(GdsErrorSummary)} requires a cascading parameter of type {nameof(EditContext)}. For example, you can use {nameof(GdsErrorSummary)} inside an {nameof(EditForm)}.");
        }
    }

    private void OnValidationStateChanged()
    {
        StateHasChanged();
    }
}
