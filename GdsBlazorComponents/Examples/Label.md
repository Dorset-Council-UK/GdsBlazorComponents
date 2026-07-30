# Label

Render a GOV.UK Design System styled label associated with a form control.

## How it works

- Renders a `<label class="govuk-label">` element.
- `For` optional parameter to set the `for` attribute of the label.
  The id of the associated input control. If no `For` is provided and used within `GdsFormGroup`, the associated GDS input control id will be used automatically.
- `Text` optional parameter to set the label text.
- `Size` optional parameter to change the size of the label.
- `CssClass` optional parameter allows you override the base CSS class.
- `AdditionalCssClasses` optional parameter allows you to add additional CSS classes.

## Variants

All label components work the same way, but with different CSS classes applied.

The following components are available:
- GdsLabel - see [GdsInputText](InputText.md)
- GdsCheckboxLabel - see [GdsInputCheckbox](InputCheckbox.md)
- GdsDateLabel
- GdsRadioLabel - see [GdsInputRadio](InputRadio.md)

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
<textarea id="more-detail" class="govuk-textarea" name="moreDetail" rows="5"></textarea>
```
