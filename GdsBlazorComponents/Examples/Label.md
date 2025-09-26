# Label

Render a GOV.UK Design System styled `<label>` that associates with a form control. Works standalone (explicit `for`) or by consuming a cascaded control id provided by `GdsFormGroup`.

## How it works

- Renders `<label class="govuk-label">` with optional extra classes.
- The label `for` attribute is set from `For`. If omitted, it falls back to a cascaded id provided by `GdsFormGroup`.

## Simple example with explicit `for`

```
<GdsLabel For="first-name" Text="First name" />
<InputText id="first-name" class="govuk-input" @bind-Value="firstName" />
```

## Example using a cascaded id

```
<GdsFormGroup For="() => Model.EventName">
    <GdsLabel Text="What is the name of the event?" />
    <GdsHint>The name you’ll use on promotional material</GdsHint>
    <GdsErrorMessage />
    <GdsInputText @bind-Value=Model.EventName class="govuk-input govuk-input--width-50" />
</GdsFormGroup>
```

## Example with additional classes

```
<GdsLabel For="more-detail" Text="Can you provide more detail?" AdditionalCssClasses="govuk-label--l" />
<textarea class="govuk-textarea" id="more-detail" name="moreDetail" rows="5"></textarea>
```
