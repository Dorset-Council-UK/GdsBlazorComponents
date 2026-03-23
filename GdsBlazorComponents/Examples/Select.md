# Select List

Render GOV.UK Design System styled select lists using the options from a list of [GdsOptionItem<T>](GdsOptionItem.md). This component supports any type of value and can be used for single selections.

> [!CAUTION]
> The select component should only be used as a last resort in public-facing services because research shows that some users find selects very difficult to use.

## Example image

![Select list example](Select.png)

## How it works

- Renders a list of [GdsOptionItem](GdsOptionItem.md) under a ```<select class="govuk-select">```.
- Supports binding to any value type (e.g., string, int, enum, bool, custom types).
- You can use the `OnChange` event callback to trigger actions when the selection changes.
- The default class is `govuk-select`, but you can use `AdditionalCssClasses` to style the select.
- The `id` attribute must be set via the `Id` parameter (not an `id=` attribute). If `Id` is omitted, it falls back to a cascaded id provided by `GdsFormGroup`. Using both a cascaded `Id` and an `id=` attribute can cause Blazor to throw a duplicate attribute error at runtime.

## Simple example

```csharp
<GdsSelect Options="@ContactTypes" T="int" OnChange="OnContactTypeChange" />
<span id="result-body">@Result</span>

@code {
    private string Result = string.Empty;
    private IReadOnlyCollection<GdsOptionItem<int>> ContactTypes = [
        new ("contactTypeNone", "Select an option", 0),
        new ("contactTypePhone", "Phone", 1),
        new ("contactTypeEmail", "Email", 2),
        new ("contactTypeText", "Text message", 3),
        new ("contactTypePost", "Post", 4),
    ];

    private async Task OnContactTypeChange(GdsOptionItem<int> option)
    {
        // Do something when the select value changes
        Result = $"Selected contact type: {option.Value} - {option.Label}";
    }
}
```