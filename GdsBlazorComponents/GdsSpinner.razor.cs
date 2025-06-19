using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public partial class GdsSpinner
{
    [Parameter, EditorRequired]
    public bool Show { get; set; }

    [Parameter]
    public string Message { get; set; } = "Loading...";


    [Parameter]
    public bool ShowMessage { get; set; }
}
