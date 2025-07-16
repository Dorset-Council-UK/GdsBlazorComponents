using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace GdsBlazorComponents
{
    public partial class GdsFileInput : IDisposable
    {
        [CascadingParameter]
        private EditContext EditContext { get; set; } = default!;
        /// <summary>
        /// The property that this input is bound to. Used for validation
        /// </summary>
        [Parameter, EditorRequired]
        public Expression<Func<object>> For { get; set; } = default!;
        /// <summary>
        /// Event callback that is triggered when files are submitted.
        /// </summary>
        [Parameter, EditorRequired]
        public EventCallback<IReadOnlyList<IBrowserFile>?> OnFilesSubmitted { get; set; }
        /// <summary>
        /// Label to place on component
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// ID of the component
        /// </summary>
        [Parameter]
        public string? Id { get; set; }
        /// <summary>
        /// A boolean that can be passed to hook into the busy state of the component.
        /// </summary>
        [Parameter]
        public bool? IsBusy { get; set; } = false;
        /// <summary>
        /// <para>Whether to show the most recent error message on the component itself. Defaults to true</para>
        /// <para>Set to false if you are using validation summaries or another suitable error message elsewhere</para>
        /// </summary>
        [Parameter]
        public bool ShowErrorOnComponent { get; set; } = true;

        IReadOnlyList<IBrowserFile>? SelectedFiles;

        private readonly ILogger<GdsFileInput> _logger;

        private string? _errorMessage;
        private readonly EventHandler<ValidationStateChangedEventArgs>? _validationStateChangedHandler;
        private FieldIdentifier _fieldIdentifier;

        private string _formGroupCssClass = "govuk-form-group";
        private string? _errorId;

        public GdsFileInput(ILogger<GdsFileInput> logger)
        {
            _logger = logger;
            _validationStateChangedHandler = (sender, args) => OnValidationStateChanged();
        }

        protected override void OnInitialized()
        {

            _fieldIdentifier = FieldIdentifier.Create(For);

            Id ??= _fieldIdentifier.FieldName;
            _errorId = $"{Id}-error";
            // Subscribe to validation state changes
            if (_validationStateChangedHandler != null)
            {
                EditContext.OnValidationStateChanged += _validationStateChangedHandler;
            }
        }
        public void Dispose()
        {
            try
            {
                // Unsubscribe from validation state changes
                if (_validationStateChangedHandler != null)
                {
                    EditContext.OnValidationStateChanged -= _validationStateChangedHandler;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to unsubscribe from validation state changes in GdsFileInput component.");
            }

            GC.SuppressFinalize(this);
        }
        private async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            SelectedFiles = e.GetMultipleFiles(50);

            if (OnFilesSubmitted.HasDelegate)
            {
                await OnFilesSubmitted.InvokeAsync(SelectedFiles);
            }
        }
        private void OnValidationStateChanged()
        {
            _errorMessage = EditContext.GetValidationMessages(_fieldIdentifier).FirstOrDefault();
            var hasError = _errorMessage != null;

            _formGroupCssClass = ShowErrorOnComponent && hasError ? $"govuk-form-group govuk-form-group--error" : "govuk-form-group";
        }
    }
}