# JavaScript Interop

Helper for loading and initializing GOV.UK Design System JavaScript in Blazor.

The `GdsJsInterop` service, defined by the `IGdsJsInterop` interface, allows Blazor components to safely load and initialize GDS JavaScript modules. This is essential for enabling interactive GOV.UK features after the Blazor page has rendered, ensuring scripts are ready before user interaction.

## How it works

- The `GdsJsInterop` class uses Blazor's JavaScript interop to import and initialize the GDS JavaScript module.
- The `InitGds` method loads the script and calls its initialization function.
- The service can be injected into Blazor components and called during the component lifecycle (e.g., after first render).
- The interface `IGdsJsInterop` defines the available initialization methods, including support for cancellation tokens.
- Ensures GOV.UK Design System scripts are loaded before interactive features are used.

## Simple example

```
@inject IGdsJsInterop gdsJs
@code {
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
              await gdsJs.InitGds();
        }
    }
}

```

## Example with cancellation token

```
@inject IGdsJsInterop gdsJs
@code {
    private CancellationTokenSource _cts = new();
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
              await gdsJs.InitGds(_cts.Token);
        }
    }

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}

```