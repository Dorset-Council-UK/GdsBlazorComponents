# Error Message

Render a GOV.UK Design System styled error message that associates with a form control.

## Example image

![Error message](ErrorMessage.png)

## How it works

- Renders `<p class="govuk-error-message">`.
- The `id` attribute is optional, letting you choose the error message id.
- If `id` is not set, a default error message id is generated and stored in the `GdsFormGroup`.

## Notes

You never manually set the error message text. It is automatically populated from the Blazor validation system when there are validation errors for the associated field.

## Simple example with explicit `id`

```csharp
<GdsErrorMessage Id="event-name-error" />
<InputText id="event-name" class="govuk-input" @bind-Value="Model.EventName" />
```

## Simple example

```csharp
<GdsFormGroup For="() => Model.EventName">
    <GdsLabel Text="What is the name of the event?" />
    <GdsHint>The name you'll use on promotional material</GdsHint>
    <GdsErrorMessage />
    <GdsInputText @bind-Value=Model.EventName class="govuk-input govuk-input--width-50" />
</GdsFormGroup>
```