using Microsoft.AspNetCore.Components.Forms;
namespace GdsBlazorComponents;

public readonly record struct FileInputResult(IReadOnlyList<IBrowserFile?> AcceptedFiles, IReadOnlyList<RejectedFile> RejectedFiles);