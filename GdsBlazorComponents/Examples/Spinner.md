# Spinner

Render a Blazor loading spinner.

The spinner is useful during the Blazor component lifecycle, especially while loading GDS JavaScript or waiting for the page to finish loading data, providing users with a clear indication that content is being prepared.

## Example images

![Spinner example 1](Spinner1.png)

![Spinner example 2](Spinner2.png)

## How it works

- Renders a spinning loading animation and an optional message.
- The spinner is shown when the `Show` parameter is set to `true`.
- The loading message can be customized via the `Message` parameter (default: "Loading...").
- The message is visually hidden by default for accessibility, but can be displayed next to the spinner by setting `ShowMessage` to `true`.
- The component is accessible, with the spinner using `role="status"` and the message available to screen readers.

## Simple example

```csharp
var isLoading = true;
<GdsSpinner Show="@isLoading" />
```

## Example with a custom message

```csharp
var isSearching = true;
<GdsSpinner Show="@isSearching" ShowMessage="true" Message="Searching, lets see what I can find..." />
```

## Comprehensive example

```csharp
<GdsSpinner Show="_isLoading" ShowMessage="true" />

@code {
    private bool _isLoading = true;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
              await gdsJs.InitGds();
             _isLoading = false;
        }
    }
}
```
