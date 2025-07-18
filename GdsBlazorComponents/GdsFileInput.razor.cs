using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace GdsBlazorComponents
{
    public partial class GdsFileInput
    {

        /// <summary>
        /// Event callback that is triggered when files are submitted.
        /// </summary>
        [Parameter, EditorRequired]
        public EventCallback<IReadOnlyList<IBrowserFile>?> OnFilesSubmitted { get; set; }
        /// <summary>
        /// ID of the component
        /// </summary>
        [CascadingParameter]
        public string? Id { get; set; }
        /// <summary>
        /// A boolean that can be passed to hook into the busy state of the component.
        /// </summary>
        [Parameter]
        public bool? IsBusy { get; set; } = false;

        IReadOnlyList<IBrowserFile>? SelectedFiles;

        private async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            SelectedFiles = e.GetMultipleFiles(50);

            if (OnFilesSubmitted.HasDelegate)
            {
                await OnFilesSubmitted.InvokeAsync(SelectedFiles);
            }
        }
    }
}