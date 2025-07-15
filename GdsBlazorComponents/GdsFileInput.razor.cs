using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace GdsBlazorComponents
{
    public partial class GdsFileInput
    {
        [CascadingParameter]
        private EditContext EditContext { get; set; } = default!;

        [Parameter, EditorRequired]
        public Expression<Func<object>> For { get; set; } = default!;
        /// <summary>
        /// The maximum file size in megabytes per file that can be uploaded. Defaults to 20 MB.
        /// </summary>
        [Parameter]
        public int MaxFileSizeMB { get; set; } = 20;
        /// <summary>
        /// The maximum number of files that can be uploaded at once. Defaults to 10.
        /// </summary>
        [Parameter]
        public int MaxAllowedFiles { get; set; } = 10;
        /// <summary>
        /// The list of allowed file types for upload. This should be a list of mime types (e.g., "image/png", "application/pdf").
        /// </summary>
        [Parameter, EditorRequired]
        public required string[] AllowedFileTypes { get; set; }
        /// <summary>
        /// Event callback that is triggered when valid files are submitted.
        /// </summary>
        [Parameter, EditorRequired]
        public EventCallback<FileInputResult> OnValidFilesSubmitted { get; set; }
        /// <summary>
        /// Event callback that is triggered when an error occurs during file input.
        /// </summary>
        [Parameter]
        public EventCallback<Exception> OnFileInputError { get; set; }
        /// <summary>
        /// The text label for the file input field.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        [Parameter]
        public string? Id { get; set; }
        [Parameter]
        public bool? IsBusy { get; set; } = false;
        private long MaxFileSize = 20 * (1024 * 1024);
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
            MaxFileSize = MaxFileSizeMB * (1024 * 1024);
            _fieldIdentifier = FieldIdentifier.Create(For);
            Id ??= _fieldIdentifier.FieldName;
            _errorId = $"{Id}-error";
            // Subscribe to validation state changes
            EditContext.OnValidationStateChanged += _validationStateChangedHandler;
        }
        public void Dispose()
        {
            try
            {
                // Unsubscribe from validation state changes
                EditContext.OnValidationStateChanged -= _validationStateChangedHandler;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to unsubscribe from validation state changes in GdsFileInput component.");
            }

            GC.SuppressFinalize(this);
        }
        private async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            _errorMessage = null;
            SelectedFiles = e.GetMultipleFiles();
            int numFiles = SelectedFiles.Count;
            if (numFiles == 0)
            {
                return;
            }
            if (SelectedFiles.Count > MaxAllowedFiles)
            {
                //_errorMessage = "You can only select up to " + MaxAllowedFiles + " files at the same time.";
                //var ex = new TooManyFilesSelectedException(MaxAllowedFiles, SelectedFiles.Count);
                //if (OnFileInputError.HasDelegate)
                //{
                //    await OnFileInputError.InvokeAsync(ex);
                //    return;
                //}
                //throw ex; // fallback if no handler is attached
                return;
            }

            var acceptedFiles = new List<IBrowserFile>();
            var rejectedFiles = new List<RejectedFile>();

            foreach (var file in SelectedFiles)
            {
                if (file.ContentType == null || !AllowedFileTypes.Contains(file.ContentType))
                {
                    rejectedFiles.Add(new RejectedFile(file, FileRejectionReason.InvalidFileType));
                    continue;
                }
                if (file.Size > MaxFileSize)
                {
                    rejectedFiles.Add(new RejectedFile(file, FileRejectionReason.FileTooLarge));
                    continue;
                }

                acceptedFiles.Add(file);
            }

            if (OnValidFilesSubmitted.HasDelegate)
            {
                await OnValidFilesSubmitted.InvokeAsync(new FileInputResult(acceptedFiles, rejectedFiles));
            }
        }
        private void OnValidationStateChanged()
        {
            var isFieldValid = EditContext.IsValid(_fieldIdentifier);


            _errorMessage = "There was an error (this is a placeholder)";
            var hasError = _errorMessage != null;

            _formGroupCssClass = hasError ? $"govuk-form-group govuk-form-group--error" : "govuk-form-group";
        }
    }
}