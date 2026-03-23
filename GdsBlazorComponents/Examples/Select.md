# Select List

Render GOV.UK Design System styled select lists using the options from a list of [GdsOptionItem<T>](GdsOptionItem.md). This component supports any type of value and can be used for single selections.

> [!CAUTION]
> The select component should only be used as a last resort in public-facing services because research shows that some users find selects very difficult to use.

## Example image

![Select list example](Select.png)

## How it works

- Renders a list of [GdsOptionItem](GdsOptionItem.md) under a ```<select class="govuk-select">```.
- Supports binding to any value type (e.g., string, int, enum, bool, custom types).
- Bind this component to a property using `@bind-Value` to track and set the selected value.
- You can use the `OnChange` event callback to trigger actions when the selection changes.
- The default class is `govuk-select`, but you can use `CssClass` to style the select.

> [!NOTE]
> To pre-select an option, set the initial value of the bound property. The `selected` parameter in `GdsOptionItem` is maintained for internal state tracking and is not used for initialization.

## Simple example

```csharp
<GdsSelect Options="@ContactTypes" @bind-Value="SelectedContactType" T="int" OnChange="OnContactTypeChange" />
<span id="result-body">@Result</span>

@code {
    private string Result = string.Empty;
    private int SelectedContactType = 1;
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