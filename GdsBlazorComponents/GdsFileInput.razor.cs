using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace GdsBlazorComponents
{
    public partial class GdsFileInput : IDisposable
    {
        [CascadingParameter]
        private EditContext? CascadedEditContext { get; set; }

        [CascadingParameter]
        private FieldContext? CascadedFieldContext { get; set; }

        [Parameter]
        public string? AdditionalCssClasses { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>
        /// Event callback that is triggered when files are submitted.
        /// </summary>
        [Parameter, EditorRequired]
        public EventCallback<IReadOnlyList<IBrowserFile>?> OnFilesSubmitted { get; set; }

        [Parameter, EditorRequired]
        public required string Id { get; set; }

        /// <summary>
        /// A boolean that can be passed to hook into the busy state of the component.
        /// </summary>
        [Parameter]
        public bool? IsBusy { get; set; } = false;

        private IReadOnlyList<IBrowserFile>? SelectedFiles;
        private FieldIdentifier? _fieldIdentifier;
        private string? _class;

        private async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            SelectedFiles = e.GetMultipleFiles(50);

            if (OnFilesSubmitted.HasDelegate)
            {
                if (CascadedEditContext is not null && _fieldIdentifier.HasValue)
                {
                    CascadedEditContext.NotifyFieldChanged(_fieldIdentifier.Value);
                }
                await OnFilesSubmitted.InvokeAsync(SelectedFiles);
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            CreateFieldIdentifier();

            _class = new CssClassBuilder("govuk-drop-zone")
                .Add(AdditionalCssClasses)
                .Build();

            // update the field context
            if (CascadedFieldContext is not null)
            {
                CascadedFieldContext.InputId = Id;
                if (_fieldIdentifier.HasValue)
                {
                    CascadedFieldContext.RegisterField(_fieldIdentifier.Value);
                }
                CascadedFieldContext.NotifyIfChanged();
            }
        }

        /// <summary>
        /// Create a field identifier for the component as InputFile does not have one
        /// </summary>
        private void CreateFieldIdentifier()
        {
            if (CascadedEditContext is null)
            {
                _fieldIdentifier = null;
                return;
            }

            var newIdentifier = CascadedEditContext.Field(Id);
            if (_fieldIdentifier.HasValue && _fieldIdentifier.Value.Equals(newIdentifier))
            {
                return;
            }

            _fieldIdentifier = newIdentifier;
        }

        public void Dispose()
        {
            if (CascadedFieldContext is not null && _fieldIdentifier.HasValue)
            {
                CascadedFieldContext.UnregisterField(_fieldIdentifier.Value);
            }
            GC.SuppressFinalize(this);
        }
    }
}