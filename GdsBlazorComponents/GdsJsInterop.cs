using Microsoft.JSInterop;

namespace GdsBlazorComponents;

public class GdsJsInterop : IGdsJsInterop, IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public GdsJsInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Dorset-Council-UK.GdsBlazorComponents/gds.js").AsTask());
    }

    public async ValueTask InitGds()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("initGDS");
    }

    public async ValueTask InitGds(CancellationToken ct)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("initGDS", ct);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
