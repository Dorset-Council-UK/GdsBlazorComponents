# Label

Render a GOV.UK Design System styled `<label>` that associates with a form control.

## How it works

- Renders `<label class="govuk-label">` with optional extra classes.
- The `For` paramater is optional, letting you choose the form control id the label is assosiated with.
- If `For` is not set, and used within `GdsFormGroup` or `GdsRadioItem`, a default for is generated.
- `Text` parameter allows you to set the label text.
- `Size` parameter allows you to set the label size.
- `CssClass` parameter allows you override the default CSS class.
- `AdditionalCssClasses` parameter allows you to add additional CSS classes.

Variants of the label component include:
- GdsLabel
- GdsCheckboxLabel
- GdsRadioLabel

See [Checkboxes](Checkboxes.md) and [Radios](Radios.md) for more information.

## Simple example with explicit `for`

```razor
<GdsLabel For="event-name" Text="Event name" />
<GdsInputText id="event-name" @bind-Value="Model.EventName" class="govuk-input govuk-input--width-50" />
```

## Full example

```razor
<GdsFormGroup>
    <GdsLabel Text="What is the name of the event?" />
    <GdsHint>The name you'll use on promotional material</GdsHint>
    <GdsErrorMessage />
    <GdsInputText @bind-Value=Model.EventName class="govuk-input govuk-input--width-50" />
</GdsFormGroup>
```

## Example with Size

```razor
<GdsLabel For="more-detail" Text="Can you provide more detail?" Size="GdsSize.Large" />
<textarea class="govuk-textarea" id="more-detail" name="moreDetail" rows="5"></textarea>
```
