using Microsoft.AspNetCore.Components.Forms;
namespace GdsBlazorComponents;

public readonly record struct RejectedFile(IBrowserFile File, FileRejectionReason FileRejectionReason);
