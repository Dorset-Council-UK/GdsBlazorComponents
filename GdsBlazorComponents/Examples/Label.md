# Label

Render a GOV.UK Design System styled `<label>` that associates with a form control.

## How it works

- Renders `<label class="govuk-label">` with optional extra classes.
- The `For` attribute is optional, letting you choose the form control id the label is assosiated with.
- If `for` is not set, the form control id stored in the `GdsFormGroup` is used.
- If `For` is not set, and used within `GdsFormGroup`, it will detect the associated GDS form control id.
- 
## Simple example with explicit `for`

```csharp
<GdsLabel For="event-name" Text="Event name" />
<GdsInputText id="event-name" @bind-Value="Model.EventName" class="govuk-input govuk-input--width-50" />
```

## Full example

```csharp
<GdsFormGroup>
    <GdsLabel Text="What is the name of the event?" />
    <GdsHint>The name you'll use on promotional material</GdsHint>
    <GdsErrorMessage />
    <GdsInputText @bind-Value=Model.EventName class="govuk-input govuk-input--width-50" />
</GdsFormGroup>
```

## Example with additional classes

```csharp
<GdsLabel For="more-detail" Text="Can you provide more detail?" AdditionalCssClasses="govuk-label--l" />
<textarea class="govuk-textarea" id="more-detail" name="moreDetail" rows="5"></textarea>
```
